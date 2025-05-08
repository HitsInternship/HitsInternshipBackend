using DeanModule.Domain.Enums;

namespace DeanModule.Contracts.Dtos.Responses;

public record ApplicationResponseDto()
{
    //todo: add student dto
    public string? Description { get; init; }

    public DateTime Date { get; init; }

    //todo: add position dto
    //todo: add company dto
    public string? DocumentUrl { get; init; }
    public ApplicationStatus Status { get; init; }
}