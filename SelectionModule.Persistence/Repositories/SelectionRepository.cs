using SelectionModule.Contracts.Repositories;
using SelectionModule.Domain.Entites;
using SelectionModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace SelectionModule.Persistence.Repositories;

public class SelectionRepository(SelectionDbContext context)
    : BaseEntityRepository<Selection>(context), ISelectionRepository
{
}