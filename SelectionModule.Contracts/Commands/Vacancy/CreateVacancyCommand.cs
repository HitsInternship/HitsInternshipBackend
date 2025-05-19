using MediatR;
using SelectionModule.Contracts.Dtos.Requests;

namespace SelectionModule.Contracts.Commands.Vacancy;

public record CreateVacancyCommand(Guid UserId, VacancyRequestDto VacancyRequestDto) : IRequest<Unit>;