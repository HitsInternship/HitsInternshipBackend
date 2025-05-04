using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Entites;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public bool IsDeleted { get; set; }
}