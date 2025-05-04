namespace DeanModule.Contracts.Dtos.Requests;

public record SemesterRequestDto
{
    public required string SemesterName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}