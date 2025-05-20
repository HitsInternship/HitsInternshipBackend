using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthModel.Infrastructure;
using AuthModule.Contracts.Model;
using AuthModule.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.Domain.Exceptions;
using UserModule.Contracts.Repositories;

namespace AuthModel.Service.Handler;

public class TokenRefreshHandler : IRequestHandler<TokenRefreshDTO, LoginResponseDTO>
{
    private readonly AuthDbContext context;
    private readonly IRoleRepository roleRepository;
    public TokenRefreshHandler(AuthDbContext context, IRoleRepository roleRepository)
    {
        this.context = context;
        this.roleRepository = roleRepository;
    }

    public async Task<LoginResponseDTO> Handle(TokenRefreshDTO request, CancellationToken cancellationToken)
    {
        var user = await context.AspNetUsers
            .FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken, cancellationToken);

        if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            throw new Unauthorized("Невалидный или истекший refresh token");
        }

        var accessToken = await GenerateAccessToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        await context.SaveChangesAsync(cancellationToken);

        return new LoginResponseDTO
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken
        };
    }

    private async Task<string> GenerateAccessToken(AspNetUser user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthSettings.PrivateKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> { new Claim("UserId", user.UserId.ToString()) };
        
        var roles = await roleRepository.GetRolesByUserIdAsync(user.UserId.Value);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName.ToString()));
        }
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = AuthSettings.GetTokenExpires(),
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}
