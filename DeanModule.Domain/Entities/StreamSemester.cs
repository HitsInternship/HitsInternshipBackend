using Shared.Domain.Entites;

namespace DeanModule.Domain.Entities;

public class StreamSemester : BaseEntity
{
    public Guid StreamId { get; set; }
    public Guid SemesterId { get; set; }
    public int Number { get; set; }
}