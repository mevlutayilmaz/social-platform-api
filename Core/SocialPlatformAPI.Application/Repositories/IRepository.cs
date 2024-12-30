using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Domain.Entities.Common;

namespace SocialPlatformAPI.Application.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        DbSet<T> Table {  get; }
    }
}
