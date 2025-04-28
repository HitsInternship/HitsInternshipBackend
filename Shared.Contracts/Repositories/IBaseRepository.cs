using Shared.Domain.Entites;

namespace Shared.Contracts.Repositories;

public interface IBaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<bool> CheckIfExistsAsync(Guid id);
    Task<IQueryable<TEntity>> ListAllAsync();
    Task SoftDeleteAsync(Guid id);    
}