using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Persistence.Contexts;
using System.Linq.Expressions;

namespace SocialPlatformAPI.Persistence.Repositories
{
    public class ReadRepository<T>(SocialPlatformDbContext context) : IReadRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table => context.Set<T>();

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);
            if (predicate is not null) query = query.Where(predicate);
            if (orderBy is not null) query = orderBy(query);
            return query;
        }

        public IQueryable<T> GetAllByPaging(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            int pageCount = 1, int itemCount = 5, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);
            if(predicate is not null) query = query.Where(predicate);
            if(orderBy is not null) query = orderBy(query);
            return query.Skip(itemCount * (pageCount - 1)).Take(itemCount);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if(!enableTracking) query = query.AsNoTracking();
            if(include is not null) query = include(query);
            return query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(string id, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if(predicate is not null) return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }
    }
}
