using SelectionModule.Contracts.Repositories;
using SelectionModule.Domain.Entites;
using SelectionModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace SelectionModule.Persistence.Repositories;

public class CandidateRepository(SelectionDbContext context)
    : BaseEntityRepository<Candidate>(context), ICandidateRepository
{
}