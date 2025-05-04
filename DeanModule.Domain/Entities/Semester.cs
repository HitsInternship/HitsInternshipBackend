using Shared.Domain.Entites;

namespace DeanModule.Domain.Entities;

public class Semester : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
}