using System.ComponentModel.DataAnnotations;

namespace AuthModule.Domain.Entity;

public class AspNetUser
{
    [Key]
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}