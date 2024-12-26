using Microsoft.EntityFrameworkCore.Query;
using SocialPlatformAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace SocialPlatformAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);
        IQueryable<T> GetAllByPaging(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int pageCount = 1, int itemCount = 5, bool enableTracking = false);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
        Task<T> GetByIdAsync(string id, bool enableTracking = false);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
