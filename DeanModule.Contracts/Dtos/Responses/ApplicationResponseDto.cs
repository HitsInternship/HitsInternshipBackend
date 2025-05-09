using DeanModule.Domain.Enums;

namespace DeanModule.Contracts.Dtos.Responses;

/// <summary>
/// Ответ по заявке студента.
/// </summary>
public record ApplicationResponseDto
{
    /// <summary>
    /// Описание заявки.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Дата подачи заявки.
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// URL на прикреплённый документ (если имеется).
    /// </summary>
    public string? DocumentUrl { get; init; }

    /// <summary>
    /// Текущий статус заявки.
    /// </summary>
    public ApplicationStatus Status { get; init; }

    // todo: добавить DTO студента
    // todo: добавить DTO позиции
    // todo: добавить DTO компании
}