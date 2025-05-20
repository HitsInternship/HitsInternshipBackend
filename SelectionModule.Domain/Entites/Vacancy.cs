using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain.Entites;

namespace SelectionModule.Domain.Entites;

public class Vacancy : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    [ForeignKey("PositionId")]
    public required Position Position { get; set; }
    
    public required Guid PositionId { get; set; }
    
    public required Guid CompanyId { get; set; }
    
    public bool IsClosed { get; set; } = false;

    public ICollection<VacancyResponse> Responses { get; set; } = [];
}