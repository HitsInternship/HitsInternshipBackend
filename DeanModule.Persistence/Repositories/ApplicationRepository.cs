using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using DeanModule.Domain.Enums;
using DeanModule.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;

namespace DeanModule.Persistence.Repositories;

public class ApplicationRepository : BaseEntityRepository<Application>, IApplicationRepository
{
    private readonly DeanModuleDbContext _dbContext;

    public ApplicationRepository(DbContext context, DeanModuleDbContext dbContext) : base(context)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Application>> GetByStudentIdAsync(Guid studentId)
    {
        return await _dbContext.Applications.Where(a => a.StudentId == studentId).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetByCompanyId(Guid companyId)
    {
        return await _dbContext.Applications.Where(a => a.CompanyId == companyId).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetByPositionIdAsync(Guid positionId)
    {
        return await _dbContext.Applications.Where(a => a.PositionId == positionId).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetByStatusAsync(ApplicationStatus status)
    {
        return await _dbContext.Applications.Where(a => a.Status == status).ToListAsync();
    }
}