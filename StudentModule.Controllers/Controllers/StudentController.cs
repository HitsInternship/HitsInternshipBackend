﻿using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Exceptions;
using StudentModule.Contracts.Commands.StudentCommands;
using StudentModule.Contracts.Queries.StudentQueries;
using System.Security.Claims;


namespace StudentModule.Controllers.Controllers
{
    [ApiController]
    [Route("api/student/")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPatch]
        [Route("edit-student-status")]
        //todo уточнить кто имеет прао менять статус студента
        public async Task<IActionResult> EditStudentStatus(EditStudentStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPatch]
        [Route("edit-student-group")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> EditStudentGroup(EditStudentGroupCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("get-students-by-group/{groupId}")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> GetStudentsByGroup([FromRoute] Guid groupId)
        {
            var query = new GetStudentsFromGroupQuery() { GroupId = groupId };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("get-students-by-stream/{streamId}")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> GetStudentsByStream([FromRoute] Guid streamId)
        {
            var query = new GetStudentsFromStreamQuery() { streamId = streamId };
            return Ok(await _mediator.Send(query));
        }
        
        [HttpGet]
        [Route("get-student/{id}")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> GetStudentForDean([FromRoute] Guid id)
        {
            var query = new GetStudentQuery() { id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("get-student")]
        [Authorize]
        public async Task<IActionResult> GetStudent()
        {
            var userId  = User.FindFirst("UserId")?.Value;

            if (userId != null) 
            {
                var query = new GetStudentQuery() { id = new Guid(userId) };
                return Ok(await _mediator.Send(query));
            }

            else { throw new BadRequest("Invalid UserId"); }
        }
    }
}
