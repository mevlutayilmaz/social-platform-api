using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace SocialPlatformAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);
        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int pageCount = 1, int itemCount = 5, bool enableTracking = false);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
