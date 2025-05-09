using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserModule.Contracts.Commands;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Queries;

namespace UserModule.Controllers;

/// <summary>
/// Контроллер для управления пользователями.
/// </summary>
[ApiController]
[Route("api/users/")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор контроллера пользователей.
    /// </summary>
    /// <param name="mediator">MediatR для отправки команд/запросов.</param>
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Создание нового пользователя.
    /// </summary>
    /// <param name="userRequest">Данные пользователя для создания.</param>
    /// <returns>Результат выполнения команды.</returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateUserCommand(CreateUserCommand userRequest)
    {
        return Ok(await _mediator.Send(userRequest));
    }

    /// <summary>
    /// Получение информации о пользователе по ID.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Информация о пользователе.</returns>
    [HttpGet]
    [Route("{id}/info")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserInfoQuery(Guid id)
    {
        return Ok(await _mediator.Send(new GetUserInfoQuery(id)));
    }

    /// <summary>
    /// Редактирование существующего пользователя.
    /// </summary>
    /// <param name="userRequest">Данные пользователя для редактирования.</param>
    /// <returns>Результат выполнения команды.</returns>
    [HttpPost]
    [Route("edit")]
    public async Task<IActionResult> EditUserCommand(EditUserCommand userRequest)
    {
        return Ok(await _mediator.Send(userRequest));
    }
}