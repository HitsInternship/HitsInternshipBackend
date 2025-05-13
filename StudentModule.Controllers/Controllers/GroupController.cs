using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentModule.Contracts.Comands.StreamComands;
using StudentModule.Contracts.Commands.GroupCommands;
using StudentModule.Contracts.Queries.GroupQueries;
using StudentModule.Contracts.Queries.StreamQueries;


namespace StudentModule.Controllers.Controllers
{
    [ApiController]
    [Route("api/groups/")]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> CreateGroup(CreateGroupCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("edit")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> EditGroup(EditGroupCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("delete")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> DeleteGroup(DeleteGroupCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("get")]
        //[Authorize(Roles = "Dean")]
        public async Task<IActionResult> GetGroups()
        {
            var query = new GetGroupsQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}
