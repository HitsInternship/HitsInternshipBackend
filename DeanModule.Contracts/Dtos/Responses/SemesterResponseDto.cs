namespace DeanModule.Contracts.Dtos.Responses;

public class SemesterResponseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
}