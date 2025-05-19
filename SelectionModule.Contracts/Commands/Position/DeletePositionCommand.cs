using MediatR;
using Unit = System.Reactive.Unit;

namespace SelectionModule.Contracts.Commands.Position;

public record DeletePositionCommand(Guid UserId, Guid PositionId) : IRequest<Unit>;