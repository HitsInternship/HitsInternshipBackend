using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain.Entites;

namespace SelectionModule.Domain.Entites;

public class Candidate : BaseEntity
{
    public Guid UserId { get; set; }
    
    [ForeignKey("SelectionId")]
    public required Selection Selection { get; set; }
    
    public Guid SelectionId { get; set; }
}