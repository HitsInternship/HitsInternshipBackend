using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Repositories;
using Shared.Domain.Entites;

namespace Shared.Persistence.Repositories;

public class BaseEntityEntityRepository<TEntity> : GenericRepository<TEntity>, IBaseEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseEntityEntityRepository(DbContext context) : base(context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> CheckIfExistsAsync(Guid id)
    {
        return await _dbSet.AnyAsync(x => x.Id == id);
    }

    public Task<IQueryable<TEntity>> ListAllAsync()
    {
        return Task.FromResult(_dbSet.AsQueryable());
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}