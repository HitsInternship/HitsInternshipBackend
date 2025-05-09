using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserModule.Contracts.CQRS;


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
        public async Task<IActionResult> CreateUserCommand(CreateUserCommand userRequest)
        {
            return Ok(await _mediator.Send(userRequest));
        }

        [HttpGet]
        [Route("{id}/info")]
        public async Task<IActionResult> GetUserInfoQuery(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserInfoQuery(id)));
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditUserCommand(EditUserCommand userRequest)
        {
            return Ok(await _mediator.Send(userRequest));
        }
    }
}