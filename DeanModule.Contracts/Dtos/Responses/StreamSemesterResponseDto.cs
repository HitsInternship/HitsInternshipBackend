using Shared.Contracts.Dtos;

namespace DeanModule.Contracts.Dtos.Responses;

/// <summary>
/// DTO для представления связи между потоком и семестром.
/// </summary>
public record StreamSemesterResponseDto : BaseDto
{
    // TODO: добавить StreamDto, если появится

    /// <summary>
    /// Порядковый номер семестра в рамках потока.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Информация о семестре.
    /// </summary>
    public required SemesterResponseDto Semester { get; set; }
}