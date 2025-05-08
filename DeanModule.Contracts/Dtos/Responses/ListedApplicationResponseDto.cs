using DeanModule.Domain.Enums;
using Shared.Contracts.Dtos;

namespace DeanModule.Contracts.Dtos.Responses;

public record ListedApplicationResponseDto : BaseDto
{
    //todo: add student dto
    public DateTime Date { get; init; }
    //todo: add company dto
    //todo: add position dto
    public ApplicationStatus Status { get; init; }
}