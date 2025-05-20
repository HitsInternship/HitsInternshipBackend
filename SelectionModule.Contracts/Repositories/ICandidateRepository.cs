using SelectionModule.Domain.Entites;
using Shared.Contracts.Repositories;

namespace SelectionModule.Contracts.Repositories;

public interface ICandidateRepository : IBaseEntityRepository<CandidateEntity>
{
}