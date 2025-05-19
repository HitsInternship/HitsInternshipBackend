using MediatR;
using SelectionModule.Contracts.Dtos.Requests;

namespace SelectionModule.Contracts.Commands.Position;

public record UpdatePositionCommand(Guid UserId, Guid PositionId, PositionRequestDto PositionRequestDto)
    : IRequest<Unit>;