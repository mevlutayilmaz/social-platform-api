using Microsoft.Extensions.DependencyInjection;
using SocialPlatformAPI.Application.Interfaces.AutoMapper;

namespace SocialPlatformAPI.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
