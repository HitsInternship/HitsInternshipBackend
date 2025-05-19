using SelectionModule.Contracts.Repositories;
using SelectionModule.Domain.Entites;
using SelectionModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace SelectionModule.Persistence.Repositories;

public class VacancyRepository(SelectionDbContext context) : BaseEntityRepository<Vacancy>(context), IVacancyRepository
{
}