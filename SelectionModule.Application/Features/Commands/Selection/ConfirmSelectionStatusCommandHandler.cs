using MediatR;
using SelectionModule.Contracts.Commands.Selection;

namespace SelectionModule.Application.Features.Commands.Selection;

public class ConfirmSelectionStatusCommandHandler : IRequestHandler<ConfirmSelectionStatusCommand, Unit>
{
    public Task<Unit> Handle(ConfirmSelectionStatusCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}