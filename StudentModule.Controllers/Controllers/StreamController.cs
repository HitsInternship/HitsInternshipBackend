﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentModule.Contracts.Comands.StreamComands;
using StudentModule.Contracts.Queries.StreamQueries;


namespace StudentModule.Controllers.Controllers
{
    [ApiController]
    [Route("api/streams/")]
    //[Authorize(Roles = "Dean")]
    public class StreamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StreamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateStream(CreateStreamCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditStream(EditStreamCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPatch]
        [Route("edit-status")]
        public async Task<IActionResult> EditStreamStatus(EditStreamStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteStream(DeleteStreamCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetStreams()
        {
            var query = new GetStreamsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("get/{streamId}")]
        public async Task<IActionResult> GetStream([FromRoute] Guid streamId)
        {
            var query = new GetStreamQuery() {streamId = streamId };
            return Ok(await _mediator.Send(query));
        }
    }
}
