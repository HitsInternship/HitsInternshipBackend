using AuthModule.Contracts.CQRS;
using AuthModule.Contracts.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthModule.Controllers;

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
