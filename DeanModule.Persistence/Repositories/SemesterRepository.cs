using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;

namespace DeanModule.Persistence.Repositories;

public class SemesterRepository : BaseEntityRepository<Semester>, ISemesterRepository
{
    public SemesterRepository(DbContext context) : base(context)
    {
    }
}