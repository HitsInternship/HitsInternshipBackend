using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserModule.Contracts.CQRS;


namespace UserModule.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserCommand(CreateUserCommand userRequest)
        {
            return Ok(await mediator.Send(userRequest));
        }

        [HttpGet]
        [Route("{id}/info")]
        public async Task<IActionResult> GetUserInfoQuery(Guid id)
        {
            return Ok(await mediator.Send(new GetUserInfoQuery(id)));
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditUserCommand(EditUserCommand userRequest)
        {
            return Ok(await mediator.Send(userRequest));
        }
    }
}
