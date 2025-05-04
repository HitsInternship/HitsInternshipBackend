using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using DeanModule.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;

namespace DeanModule.Persistence.Repositories;

public class StreamSemesterRepository : BaseEntityRepository<StreamSemester>, IStreamSemesterRepository
{
    private readonly DeanModuleDbContext _dbContext;

    public StreamSemesterRepository(DbContext context, DeanModuleDbContext dbContext) : base(context)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<StreamSemester?>> GetByStreamIdAsync(Guid streamId)
    {
        return await _dbContext.StreamSemesters.Where(s => s.StreamId == streamId).ToListAsync();
    }

    public async Task<StreamSemester?> GetBySemesterIdAsync(Guid semesterId, int semesterNumber)
    {
        return await _dbContext.StreamSemesters.FirstOrDefaultAsync(x =>
            x != null && x.StreamId == semesterId && x.Number == semesterNumber);
    }
}