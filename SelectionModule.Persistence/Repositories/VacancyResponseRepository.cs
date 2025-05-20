using SelectionModule.Contracts.Repositories;
using SelectionModule.Domain.Entites;
using SelectionModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace SelectionModule.Persistence.Repositories;

public class VacancyResponseRepository(SelectionDbContext context)
    : BaseEntityRepository<VacancyResponse>(context), IVacancyResponseRepository
{
}