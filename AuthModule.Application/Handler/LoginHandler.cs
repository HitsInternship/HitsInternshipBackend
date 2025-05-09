using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthModel.Infrastructure;
using AuthModel.Service.Interface;
using AuthModule.Contracts.CQRS;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.Extensions.ErrorHandling.Error;

namespace AuthModel.Service.Handler;

public class LoginHandler :  IRequestHandler<LoginDTO, string>
{
    private readonly IHashService hashService;
    private readonly AuthDbContext context;
    public LoginHandler(IHashService hashService, AuthDbContext context)
    {
        this.hashService = hashService;
        this.context = context;
    }
    
    public async Task<string> Handle(LoginDTO request, CancellationToken cancellationToken)
    {
        using SHA256 sha256Hash = SHA256.Create();
        var passwordHash = hashService.GetHash(sha256Hash, request.Password);

        var user = await context.AspNetUsers
            .FirstOrDefaultAsync(u => u.Login == request.Login && u.Password == passwordHash, cancellationToken);

        if (user == null)
        {
            throw new ErrorException(404, "Пользователь не найден");
        }

        return GenerateAccessToken(user.Id);
    }
    
    private string GenerateAccessToken(Guid Id)
    {
        var handler = new JwtSecurityTokenHandler();
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthSettings.PrivateKey));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("UserId", Id.ToString()),
        };
        

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = AuthSettings.GetTokenExpires(),
            SigningCredentials = signinCredentials
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}