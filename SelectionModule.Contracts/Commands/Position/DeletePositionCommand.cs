using MediatR;

namespace SelectionModule.Contracts.Commands.Position;

public record DeletePositionCommand(Guid UserId, Guid PositionId) : IRequest<Unit>;