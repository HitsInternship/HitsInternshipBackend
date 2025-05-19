using System.ComponentModel.DataAnnotations;
using DeanModule.Contracts.Commands.Application;
using DeanModule.Contracts.Dtos.Requests;
using DeanModule.Contracts.Dtos.Responses;
using DeanModule.Contracts.Queries;
using DeanModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeanModule.Controllers.Controllers;

/// <summary>
/// Контроллер для управления заявками студентов (Applications).
/// Позволяет создавать, обновлять, удалять, просматривать заявки и изменять их статус.
/// </summary>
[ApiController]
[Route("applications")]
public class ApplicationsController : ControllerBase
{
    private readonly ISender _sender;

    public ApplicationsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Получает список заявок с возможностью фильтрации по статусу, студенту и архивности.
    /// </summary>
    /// <param name="status">Статус заявки для фильтрации (опционально).</param>
    /// <param name="studentId">Идентификатор студента (опционально).</param>
    /// <param name="isArchived">Показывать ли архивные заявки (по умолчанию false).</param>
    /// <param name="page">Номер страницы (по умолчанию 1).</param>
    /// <returns>Список заявок с пагинацией.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApplicationsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetApplications([FromQuery] ApplicationStatus? status, [FromQuery] Guid? studentId,
        bool isArchived = false, int page = 1)
    {
        return Ok(await _sender.Send(new GetApplicationsQuery(status, studentId, isArchived, page)));
    }

    /// <summary>
    /// Создает новую заявку.
    /// </summary>
    /// <param name="applicationRequestDto">Данные заявки.</param>
    /// <returns>Созданная заявка.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateApplication([FromBody] ApplicationRequestDto applicationRequestDto)
    {
        return Ok(await _sender.Send(new CreateApplicationCommand(applicationRequestDto)));
    }

    /// <summary>
    /// Обновляет существующую заявку.
    /// </summary>
    /// <param name="applicationId">Идентификатор заявки.</param>
    /// <param name="applicationRequestDto">Обновленные данные заявки.</param>
    /// <returns>Обновленная заявка.</returns>
    [HttpPut, Route("{applicationId}")]
    public async Task<IActionResult> UpdateApplication(Guid applicationId,
        [FromBody] ApplicationRequestDto applicationRequestDto)
    {
        // TODO: заменить временный userId на текущего пользователя
        return Ok(
            await _sender.Send(new UpdateApplicationCommand(applicationId, applicationRequestDto,
                Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))));
    }

    /// <summary>
    /// Удаляет или архивирует заявку.
    /// </summary>
    /// <param name="applicationId">Идентификатор заявки.</param>
    /// <param name="isArchive">Архивировать (true) или удалить (false) заявку.</param>
    /// <returns>Результат удаления или архивирования.</returns>
    [HttpDelete, Route("{applicationId}")]
    public async Task<IActionResult> DeleteApplication(Guid applicationId, [FromQuery] bool isArchive = true)
    {
        // TODO: заменить временный userId на текущего пользователя
        return Ok(await _sender.Send(new DeleteApplicationCommand(applicationId, isArchive,
            Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))));
    }

    /// <summary>
    /// Обновляет статус заявки (например, одобрена, отклонена и т.д.).
    /// </summary>
    /// <param name="applicationId">Идентификатор заявки.</param>
    /// <param name="status">Новый статус заявки (обязателен).</param>
    /// <returns>Результат обновления статуса.</returns>
    [HttpPost, Route("{applicationId}/application-status")]
    public async Task<IActionResult> ApproveApplication(Guid applicationId,
        [FromQuery, Required] ApplicationStatus status)
    {
        return Ok(await _sender.Send(new UpdateApplicationStatusCommand(applicationId, status)));
    }

    /// <summary>
    /// Получает полную информацию о конкретной заявке.
    /// </summary>
    /// <param name="applicationId">Идентификатор заявки.</param>
    /// <returns>Полная информация о заявке.</returns>
    [HttpGet, Route("{applicationId}")]
    [ProducesResponseType(typeof(ApplicationResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetApplication(Guid applicationId)
    {
        // TODO: заменить временный userId на текущего пользователя
        return Ok(await _sender.Send(new GetApplicationQuery(applicationId,
            Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))));
    }
}