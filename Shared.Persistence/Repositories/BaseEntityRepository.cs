using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Repositories;
using Shared.Domain.Entites;

namespace Shared.Persistence.Repositories;

public class BaseEntityRepository<TEntity>(DbContext context)
    : GenericRepository<TEntity>(context), IBaseEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseEntityRepository(DbContext context) : base(context)
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
        return await DbSet.AnyAsync(x => x.Id == id);
    }

    public Task<IQueryable<TEntity>> ListAllAsync()
    {
       return Task.FromResult(DbSet.Where(x=>x.IsDeleted == false).AsQueryable());
    }

    public Task<IQueryable<TEntity>> ListAllArchivedAsync()
    {
        return Task.FromResult(DbSet.Where(x=>x.IsDeleted == true).AsQueryable());
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}