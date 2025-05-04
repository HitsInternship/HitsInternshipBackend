using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;

namespace DeanModule.Persistence.Repositories;

public class DeanMemberRepository : BaseEntityRepository<DeanMember>, IDeanMemberRepository
{
    public DeanMemberRepository(DbContext context) : base(context)
    {
    }
}