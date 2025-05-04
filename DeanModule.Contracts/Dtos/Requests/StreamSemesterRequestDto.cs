namespace DeanModule.Contracts.Dtos.Requests;

public record StreamSemesterRequestDto
{
    public Guid StreamId { get; set; }
    public Guid SemesterId { get; set; }
    public int Number { get; set; }
}