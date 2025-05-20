using MediatR;

namespace SelectionModule.Contracts.Commands.VacancyResponse;

public record ChangeVacancyResponseStatusCommand() : IRequest<Unit>;