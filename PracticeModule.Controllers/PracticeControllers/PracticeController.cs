using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeModule.Contracts.Model;

namespace PracticeModule.Controllers.PracticeControllers;

[ApiController]
[Route("api/auth/")]
public class PracticeController : ControllerBase
{
    private readonly IMediator mediator;

    public PracticeController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet("student-characteristics")]
    public async Task<IActionResult> GetPractice([FromForm] StudentCharacteristicsAddQuery dto)
    {
        await mediator.Send(dto);
        return Ok();
    }
}