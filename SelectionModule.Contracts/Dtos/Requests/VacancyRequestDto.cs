namespace SelectionModule.Contracts.Dtos.Requests;

public record VacancyRequestDto
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    public required Guid PositionId { get; set; }
    
    public required Guid CompanyId { get; set; }
}