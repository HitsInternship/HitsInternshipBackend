using AutoMapper;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        ///// <summary>
        ///// Добавляет пользователя в систему.
        ///// </summary>
        ///// <returns>Добавленный пользователь.</returns>
        //[HttpPost]
        //[Route("create")]
        //[ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> CreateUserCommand(UserRequest createRequest)
        //{
        //    return Ok(_mapper.Map<UserResponse>(await mediator.Send(new CreateUserCommand(createRequest))));
        //}

        /// <summary>
        /// Возвращает информацию о пользователе.
        /// </summary>
        /// <returns>Информация о пользователе.</returns>
        [HttpGet]
        [Route("{id}/info")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserInfoQuery(Guid id)
        {
            return Ok(_mapper.Map<UserResponse>(await _mediator.Send(new GetUserQuery(id))));
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
            return Ok(_mapper.Map<UserResponse>(await _mediator.Send(new EditUserCommand(id, userRequest))));
        }
    }
}
