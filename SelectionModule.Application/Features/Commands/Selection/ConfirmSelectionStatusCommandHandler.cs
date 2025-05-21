using MediatR;
using SelectionModule.Contracts.Commands.Selection;
using SelectionModule.Contracts.Repositories;
using SelectionModule.Domain.Enums;
using Shared.Domain.Exceptions;

namespace SelectionModule.Application.Features.Commands.Selection;

public class ConfirmSelectionStatusCommandHandler : IRequestHandler<ConfirmSelectionStatusCommand, Unit>
{
    private readonly ISelectionRepository _selectionRepository;
    private readonly ICandidateRepository _candidateRepository;

    public ConfirmSelectionStatusCommandHandler(ISelectionRepository selectionRepository,
        ICandidateRepository candidateRepository)
    {
        _selectionRepository = selectionRepository;
        _candidateRepository = candidateRepository;
    }

    public async Task<Unit> Handle(ConfirmSelectionStatusCommand request, CancellationToken cancellationToken)
    {
        if (!await _selectionRepository.CheckIfExistsAsync(request.SelectionId))
            throw new NotFound("Selection doesn't exist");

        var selection = await _selectionRepository.GetByIdAsync(request.SelectionId);

        if (selection.SelectionStatus != SelectionStatus.OffersAccepted)
            throw new BadRequest("You cannot confirm selection with this status ");

        //todo: create practice
        //todo: send email notification

        await _selectionRepository.SoftDeleteAsync(selection.Id);
        await _candidateRepository.SoftDeleteAsync(selection.CandidateId);
        
        return Unit.Value;
    }
}