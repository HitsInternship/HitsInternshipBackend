using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using DeanModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace DeanModule.Persistence.Repositories;

public class DeanMemberRepository : BaseEntityRepository<DeanMember>, IDeanMemberRepository
{
    public DeanMemberRepository(DeanModuleDbContext context) : base(context)
    {
    }
}