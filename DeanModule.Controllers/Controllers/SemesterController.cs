using DeanModule.Contracts.Commands.Semester;
using DeanModule.Contracts.Dtos.Requests;
using DeanModule.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeanModule.Controllers.Controllers;

[ApiController]
[Route("semester")]
public class SemesterController : ControllerBase
{
    private readonly ISender _sender;

    public SemesterController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetSemesters([FromQuery] bool isArchive = false)
    {
        return Ok(await _sender.Send(new GetSemestersQuery(isArchive)));
    }

    [HttpPost]
    public async Task<IActionResult> AddSemester([FromBody] SemesterRequestDto semesterRequestDto)
    {
        return Ok(await _sender.Send(new CreateSemesterCommand(semesterRequestDto)));
    }

    [HttpPut, Route("{semesterId}")]
    public async Task<IActionResult> UpdateSemester(Guid semesterId, [FromBody] SemesterRequestDto semesterRequestDto)
    {
        return Ok(await _sender.Send(new UpdateSemesterCommand(semesterId, semesterRequestDto)));
    }

    [HttpDelete, Route("{semesterId}")]
    public async Task<IActionResult> DeleteSemester(Guid semesterId)
    {
        return Ok(await _sender.Send(new DeleteSemesterCommand(semesterId)));
    }
}