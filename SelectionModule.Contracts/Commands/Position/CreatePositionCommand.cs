using MediatR;
using SelectionModule.Contracts.Dtos.Requests;

namespace SelectionModule.Contracts.Commands.Position;

public record CreatePositionCommand(Guid UserId, PositionRequestDto PositionRequestDto) : IRequest<Unit>;