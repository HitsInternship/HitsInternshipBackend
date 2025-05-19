using Shared.Contracts.Dtos;

namespace SelectionModule.Contracts.Dtos.Responses;

public record VacanciesDto : BaseDto
{
    public List<ListedVacancyDto> Vacancies { get; set; }
    public Pagination Pagination { get; set; }
}