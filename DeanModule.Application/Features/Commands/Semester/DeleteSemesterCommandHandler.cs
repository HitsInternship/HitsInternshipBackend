using DeanModule.Application.Exceptions;
using DeanModule.Contracts.Commands.Semester;
using DeanModule.Contracts.Repositories;
using MediatR;

namespace DeanModule.Application.Features.Commands.Semester;

public class DeleteSemesterCommandHandler : IRequestHandler<DeleteSemesterCommand, Unit>
{
    private readonly ISemesterRepository _semesterRepository;

    public DeleteSemesterCommandHandler(ISemesterRepository semesterRepository)
    {
        _semesterRepository = semesterRepository;
    }

    public async Task<Unit> Handle(DeleteSemesterCommand request, CancellationToken cancellationToken)
    {
        if (!await _semesterRepository.CheckIfExistsAsync(request.SemesterId))
            throw new SemesterNotFound(request.SemesterId);

        if (request.Archive)
            await _semesterRepository.SoftDeleteAsync(request.SemesterId);
        else
            await _semesterRepository.DeleteAsync(await _semesterRepository.GetByIdAsync(request.SemesterId));

        return Unit.Value;
    }
}