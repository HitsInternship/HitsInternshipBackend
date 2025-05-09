using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs.Requests;
using UserModule.Contracts.DTOs.Responses;


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

        /// <summary>
        /// Добавляет пользователя в систему.
        /// </summary>
        /// <returns>Добавленный пользователь.</returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUserCommand(UserRequest createRequest)
        {
            return Ok(new UserResponse(await mediator.Send(new CreateUserCommand(createRequest))));
        }

        /// <summary>
        /// Возвращает информацию о пользователе.
        /// </summary>
        /// <returns>Информация о пользователе.</returns>
        [HttpGet]
        [Route("{id}/info")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserInfoQuery(Guid id)
        {
            return Ok(new UserResponse(await mediator.Send(new GetUserQuery(id))));
        }

        /// <summary>
        /// Изменяет информацию о пользователе.
        /// </summary>
        /// <returns>Измененный пользователь.</returns>
        [HttpPost]
        [Route("{id}/edit")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditUserCommand(Guid id, UserRequest userRequest)
        {
            return Ok(new UserResponse(await mediator.Send(new EditUserCommand(id, userRequest))));
        }
    }
}
