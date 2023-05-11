using Microsoft.EntityFrameworkCore;

namespace Messenger.Repository.Base;

public interface IGenericRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
{
    Task<TEntity> CreateAsync(TEntity obj, CancellationToken token = default);
    Task<TEntity?> TryCreateAsync(TEntity obj, CancellationToken token = default);

    Task<TEntity> UpdateAsync(TEntity obj, CancellationToken token = default);
    Task<bool> TryUpdateAsync(TEntity obj, CancellationToken token = default);
}
