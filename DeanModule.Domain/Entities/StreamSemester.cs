using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain.Entites;

namespace DeanModule.Domain.Entities;

public class StreamSemester : BaseEntity
{
    public Guid StreamId { get; set; }

    [ForeignKey("Semester")]
    public Guid SemesterId { get; set; }
    
    [Required]
    public int Number { get; set; }

    [Required]
    public SemesterEntity SemesterEntity { get; set; }
}