using AuthModule.Contracts.CQRS;
using MediatR;
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

    [HttpPut("refreshToken")]
    public async Task<IActionResult> RefreshToken(string token)
    {
        return Ok();
    }
    
    
}