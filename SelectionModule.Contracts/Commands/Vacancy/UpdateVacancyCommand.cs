using MediatR;
using SelectionModule.Contracts.Dtos.Requests;

namespace SelectionModule.Contracts.Commands.Vacancy;

public record UpdateVacancyCommand(Guid UserId, Guid VacancyId, VacancyRequestDto VacancyRequestDto) : IRequest<Unit>;