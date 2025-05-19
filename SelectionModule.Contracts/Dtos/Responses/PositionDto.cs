using Shared.Contracts.Dtos;

namespace SelectionModule.Contracts.Dtos.Responses;

public record PositionDto : BaseDto
{
    public string Name { get; set; }
    public string? Description {get; set; }
}