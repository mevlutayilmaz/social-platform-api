using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Persistence.Contexts;
using System.Linq.Expressions;

namespace SocialPlatformAPI.Persistence.Repositories
{
    public class ReadRepository<T>(SocialPlatformDbContext context) : IReadRepository<T> where T : class, new()
    {
        public DbSet<T> Table => context.Set<T>();

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);
            if (predicate is not null) query = query.Where(predicate);
            if (orderBy is not null) query = orderBy(query);
            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            int pageCount = 1, int itemCount = 5, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);
            if(predicate is not null) query = query.Where(predicate);
            if(orderBy is not null) query = orderBy(query);
            return await query.Skip(itemCount * (pageCount - 1)).Take(itemCount).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if(!enableTracking) query = query.AsNoTracking();
            if(include is not null) query = include(query);
            return await query.FirstOrDefaultAsync(predicate);
        }

        

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if(predicate is not null) return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }
    }
}
