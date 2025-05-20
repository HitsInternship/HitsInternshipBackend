using MediatR;

namespace SelectionModule.Contracts.Commands.VacancyResponse;

public record CreateVacancyResponseCommand() : IRequest<Unit>;