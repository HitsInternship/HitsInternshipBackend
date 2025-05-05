using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Entites;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get;  } = Guid.NewGuid();

    public bool IsDeleted { get; set; }
}