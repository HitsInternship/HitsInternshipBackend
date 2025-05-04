using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using DeanModule.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;

namespace DeanModule.Persistence.Repositories;

public class StreamSemesterRepository : BaseEntityRepository<StreamSemester>, IStreamSemesterRepository
{
    public StreamSemesterRepository(DeanModuleDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<StreamSemester>> GetByStreamIdAsync(Guid streamId)
    {
        return await DbSet.Where(s => s.StreamId == streamId).ToListAsync();
    }

    public async Task<StreamSemester?> GetBySemesterIdAsync(Guid semesterId, int semesterNumber)
    {
        return await DbSet.FirstOrDefaultAsync(x =>
            x.StreamId == semesterId && x.Number == semesterNumber);
    }
}