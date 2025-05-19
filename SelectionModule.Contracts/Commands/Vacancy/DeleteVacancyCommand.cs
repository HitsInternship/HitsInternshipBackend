using MediatR;

namespace SelectionModule.Contracts.Commands.Vacancy;

public record DeleteVacancyCommand(Guid UserId, Guid VacancyId, bool ToArchive) : IRequest<Unit>;