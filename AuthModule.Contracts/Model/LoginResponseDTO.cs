using UserModule.Domain.Entities;

namespace AuthModule.Contracts.Model;

public class LoginResponseDTO
{
     public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public List<Role> Roles { get; set; }
}