using CompanyModule.Contracts.DTOs.Responses;

namespace SelectionModule.Contracts.Dtos.Responses;

/// <summary>
/// DTO для краткого отображения информации о вакансии.
/// </summary>
public class ListedVacancyDto
{
    /// <summary>
    /// Название вакансии.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Должность, связанная с вакансией.
    /// </summary>
    public required PositionDto Position { get; set; }

    /// <summary>
    /// Компания, разместившая вакансию.
    /// </summary>
    public required ShortenCompanyDto Company { get; set; }

    /// <summary>
    /// Признак закрытия вакансии.
    /// </summary>
    public bool IsClosed { get; set; } = false;
}