using MediatR;
using SelectionModule.Contracts.Dtos.Responses;

namespace SelectionModule.Contracts.Queries;

public record GetVacanciesQuery(Guid VacancyId, Guid CompanyId, bool IsClosed, bool IsArchived)
    : IRequest<VacanciesDto>;