using AuthModule.Contracts.CQRS;
using AuthModule.Contracts.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Exceptions;

namespace AuthModule.Controlllers;

[ApiController]
[Route("api/auth/")]
public class AuthController: ControllerBase
{

    private readonly IMediator mediator;
    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var token = await mediator.Send(loginDTO);
        return Ok(new { Token = token });
    }
    [HttpPut("edit/pass")]
    [Authorize]
    public async Task<IActionResult> Login(EditPasswordDTO password)
    {
        var userId = User.FindFirst("UserId")?.Value;
        if (userId == null) throw new Unauthorized("UserId - not found");
        
        var newPassword = new EditPasswordQuery()
        {
            OldPassword = password.OldPassword,
            NewPassword = password.NewPassword,
            UserId = Guid.Parse(userId),
            Login = password.Login,
        };
        await mediator.Send(newPassword);
        return Ok();
    }
    
    [HttpPost("getRoleById")]
    public async Task<IActionResult> GetMyRole(GetRoleQuery query)
    {
        var role = await mediator.Send(query);
        return Ok(role);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRefreshDTO dto)
    {
        var tokens = await mediator.Send(dto);
        return Ok(tokens);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var userId = User.FindFirst("UserId").Value;

        if (userId == null)
        {
            return Unauthorized(new { Message = "Invalid or missing user ID in token" });
        }

        await mediator.Send(new LogoutDTO { UserId = Guid.Parse(userId) });
        return Ok(new { Message = "Logout successful" });
    }
    
}
