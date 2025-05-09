using DeanModule.Domain.Enums;
using Shared.Contracts.Dtos;

namespace DeanModule.Contracts.Dtos.Responses;

/// <summary>
/// Упрощённая информация о заявке.
/// </summary>
public record ListedApplicationResponseDto : BaseDto
{
    /// <summary>
    /// Дата подачи заявки.
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// Статус заявки.
    /// </summary>
    public ApplicationStatus Status { get; init; }

    // todo: добавить DTO студента
    // todo: добавить DTO компании
    // todo: добавить DTO позиции
}