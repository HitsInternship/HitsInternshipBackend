namespace DeanModule.Contracts.Dtos.Requests;

public record SemesterRequestDto
{
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}