using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<bool> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                bool result = false;
                EntityEntry addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                if (addedEntity.State == EntityState.Added)
                    result = true;
                await context.SaveChangesAsync();
                return result;
            }
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().AddRange(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                bool result = false;
                EntityEntry deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                if (deletedEntity.State == EntityState.Deleted)
                    result = true;
                await context.SaveChangesAsync();
                return result;
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().RemoveRange(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                bool result = false;
                EntityEntry updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                if (updatedEntity.State == EntityState.Modified)
                    result = true;
                await context.SaveChangesAsync();
                return result;
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().UpdateRange(entities);
                await context.SaveChangesAsync();
            }
        }
    }
}
