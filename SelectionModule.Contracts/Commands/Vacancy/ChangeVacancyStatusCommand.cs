using MediatR;

namespace SelectionModule.Contracts.Commands.Vacancy;

public record ChangeVacancyStatusCommand(Guid UserId, Guid VacancyId) : IRequest<Unit>;