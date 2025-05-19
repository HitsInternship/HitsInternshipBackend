namespace SelectionModule.Contracts.Dtos.Requests;

public record PositionRequestDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
}