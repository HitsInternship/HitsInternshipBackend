using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Entites;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}