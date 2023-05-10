using Microsoft.EntityFrameworkCore;

namespace Messenger.Repository.Base
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context;
        protected DbSet<TEntity> DbSet;

        public GenericRepository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }


        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
