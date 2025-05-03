using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserModule.Contracts.DTOs;
using UserModule.Controllers.CQRS.Queries;


namespace UserModule.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddUserCommand(UserDTO userRequest)
        {
            UserDTO UserInfo = await _mediator.Send(new AddUserCommand(userRequest));

            return Ok(UserInfo);
        }

        [HttpGet]
        [Route("{id}/info")]
        public async Task<IActionResult> GetUserInfoQuery(Guid id)
        {
            UserDTO UserInfo = await _mediator.Send(new GetUserInfoQuery(id));

            return Ok(UserInfo);
        }
    }
}
