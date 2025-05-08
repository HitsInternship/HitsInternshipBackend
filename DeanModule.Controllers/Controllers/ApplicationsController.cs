using System.ComponentModel.DataAnnotations;
using DeanModule.Contracts.Commands.Application;
using DeanModule.Contracts.Dtos.Requests;
using DeanModule.Contracts.Queries;
using DeanModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeanModule.Controllers.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationsController : ControllerBase
{
    private readonly ISender _sender;

    public ApplicationsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetApplications([FromQuery] ApplicationStatus? status, [FromQuery] Guid? studentId,
        bool isArchived = false, int page = 1)
    {
        return Ok(await _sender.Send(new GetApplicationsQuery(status, studentId, isArchived, page)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication([FromBody] ApplicationRequestDto applicationRequestDto)
    {
        return Ok(await _sender.Send(new CreateApplicationCommand(applicationRequestDto)));
    }

    [HttpPut, Route("{applicationId}")]
    public async Task<IActionResult> UpdateApplication(Guid applicationId,
        [FromBody] ApplicationRequestDto applicationRequestDto)
    {
        //todo: add user id
        return Ok(
            await _sender.Send(new UpdateApplicationCommand(applicationId, applicationRequestDto,
                Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))));
    }

    [HttpDelete, Route("{applicationId}")]
    public async Task<IActionResult> DeleteApplication(Guid applicationId, [FromQuery] bool isArchive = true)
    {
        //todo: add user id

        return Ok(await _sender.Send(new DeleteApplicationCommand(applicationId, isArchive,
            Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))));
    }

    [HttpPost, Route("{applicationId}/application-status")]
    public async Task<IActionResult> ApproveApplication(Guid applicationId,
        [FromQuery, Required] ApplicationStatus status)
    {
        return Ok(await _sender.Send(new UpdateApplicationStatusCommand(applicationId, status)));
    }

    [HttpGet, Route("{applicationId}")]
    public async Task<IActionResult> GetApplication(Guid applicationId)
    {
        return Ok(await _sender.Send(new GetApplicationQuery(applicationId,
            Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))));
    }
}