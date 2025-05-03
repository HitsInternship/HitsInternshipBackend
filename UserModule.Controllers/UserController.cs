using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserModule.Contracts.DTOs;
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
            UserDTO UserInfo = await mediator.Send(userRequest);

            return Ok(UserInfo);
        }

        [HttpGet]
        [Route("{id}/info")]
        public async Task<IActionResult> GetUserInfoQuery(Guid id)
        {
            UserDTO UserInfo = await mediator.Send(new GetUserInfoQuery(id));

            return Ok(UserInfo);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditUserCommand(EditUserCommand userRequest)
        {
            UserDTO UserInfo = await mediator.Send(userRequest);

            return Ok(UserInfo);
        }
    }
}
