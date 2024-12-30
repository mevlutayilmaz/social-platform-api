using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Persistence.Contexts;

namespace SocialPlatformAPI.Persistence.Repositories
{
    public class WriteRepository<T>(SocialPlatformDbContext context) : IWriteRepository<T> where T : class, new()
    {
        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FindAsync(Guid.Parse(id));
            return Remove(model);
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public Task<int> SaveAsync()
            => context.SaveChangesAsync();
    }
}
