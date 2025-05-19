using System.ComponentModel.DataAnnotations.Schema;
using SelectionModule.Domain.Enums;
using Shared.Domain.Entites;

namespace SelectionModule.Domain.Entites;

public class Selection : BaseEntity
{
    public required DateTime DeadLine { get; set; }
    
    [ForeignKey("CandidateId")]
    public required Candidate Candidate { get; set; }
    
    public required Guid CandidateId { get; set; }
    
    public required SelectionStatus SelectionStatus { get; set; }
}