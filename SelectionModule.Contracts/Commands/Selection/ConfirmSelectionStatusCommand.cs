using MediatR;

namespace SelectionModule.Contracts.Commands.Selection;

public record ConfirmSelectionStatusCommand(Guid UserId, Guid SelectionId) : IRequest<Unit>;