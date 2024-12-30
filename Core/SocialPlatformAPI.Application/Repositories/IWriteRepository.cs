using SocialPlatformAPI.Domain.Entities.Common;

namespace SocialPlatformAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, new() 
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> RemoveAsync(string id);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
