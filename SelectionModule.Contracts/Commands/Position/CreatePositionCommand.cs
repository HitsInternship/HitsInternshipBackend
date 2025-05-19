using MediatR;
using SelectionModule.Contracts.Dtos.Requests;
using Unit = System.Reactive.Unit;

namespace SelectionModule.Contracts.Commands.Position;

public record CreatePositionCommand(Guid UserId, PositionRequestDto PositionRequestDto) : IRequest<Unit>;