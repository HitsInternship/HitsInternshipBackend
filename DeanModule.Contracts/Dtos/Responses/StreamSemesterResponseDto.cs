namespace DeanModule.Contracts.Dtos.Responses;

public class StreamSemesterResponseDto
{
    //todo: add streamDto
    
    public int Number { get; set; }

    public required SemesterResponseDto Semester { get; set; }
}