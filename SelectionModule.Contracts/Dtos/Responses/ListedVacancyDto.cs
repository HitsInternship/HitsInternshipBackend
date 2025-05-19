using CompanyModule.Contracts.DTOs.Responses;

namespace SelectionModule.Contracts.Dtos.Responses;

public class ListedVacancyDto
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    public required PositionDto Position { get; set; }
    
    public required CompanyResponse Company { get; set; }
    
    public bool IsClosed { get; set; } = false;
}