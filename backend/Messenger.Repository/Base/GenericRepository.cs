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

        public async Task<TEntity> CreateAsync(TEntity obj, CancellationToken token = default)
        {
            try
            {
                var result = await Context.AddAsync(obj, token);
                var expectedRows = Context.ChangeTracker.Entries<TEntity>()
                    .Count(x => x.State is EntityState.Added);

                var resultRows = await Context.SaveChangesAsync(token);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //exception handling
                throw;
            }
        }

        public async Task<TEntity?> TryCreateAsync(TEntity obj, CancellationToken token = default)
        {
            try
            {
                var result = await CreateAsync(obj, token);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken token = default)
        {
            try
            {
                var result = Context.Update(obj);
                var expectedRows = Context.ChangeTracker.Entries<TEntity>()
                    .Count(x => x.State is EntityState.Modified);

                var resultRows = await Context.SaveChangesAsync(token);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //exception handling
                throw;
            }
        }

        public async Task<bool> TryUpdateAsync(TEntity obj, CancellationToken token = default)
        {
            try
            {
                await UpdateAsync(obj, token);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
