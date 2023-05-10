using Microsoft.EntityFrameworkCore;

namespace Messenger.Repository.Base;

public interface IGenericRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
{
    Task<TEntity?> FindByIdAsync(int id);
}
