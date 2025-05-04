using DeanModule.Contracts.Commands.StreamSemester;
using DeanModule.Contracts.Dtos.Requests;
using DeanModule.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeanModule.Controllers.Controllers;

[ApiController]
[Route("stream-semester")]
public class StreamSemesterController : ControllerBase
{
    private readonly ISender _sender;

    public StreamSemesterController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStreamSemester([FromBody] StreamSemesterRequestDto streamSemesterRequestDto)
    {
        return Ok(await _sender.Send(new CreateStreamSemesterCommand(streamSemesterRequestDto)));
    }

    [HttpPut, Route("{id}")]
    public async Task<IActionResult> UpdateStreamSemester(Guid id,
        [FromBody] StreamSemesterRequestDto streamSemesterRequestDto)
    {
        return Ok(await _sender.Send(new UpdateStreamSemester(id, streamSemesterRequestDto)));
    }

    [HttpDelete, Route("{id}")]
    public async Task<IActionResult> DeleteStreamSemester(Guid id)
    {
        return Ok(await _sender.Send(new DeleteStreamSemesterCommand(id)));
    }

    [HttpGet, Route("{streamId}")]
    public async Task<IActionResult> GetStreamSemesters(Guid streamId)
    {
        return Ok(await _sender.Send(new GetStreamSemestersByStreamCommand(streamId)));
    }
}