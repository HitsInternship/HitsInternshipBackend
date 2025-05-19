using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain.Entites;

namespace SelectionModule.Domain.Entites;

public class Selection : BaseEntity
{
    public required DateTime DeadLine { get; set; }
    
    [ForeignKey("CandidateId")]
    public Candidate Candidate { get; set; }
    
    public Guid CandidateId { get; set; }
}