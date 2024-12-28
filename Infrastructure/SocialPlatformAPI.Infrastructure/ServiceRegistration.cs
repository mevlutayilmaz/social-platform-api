using Microsoft.Extensions.DependencyInjection;
using SocialPlatformAPI.Application.Interfaces.Storage;
using SocialPlatformAPI.Application.Interfaces.Tokens;
using SocialPlatformAPI.Infrastructure.Services.Storage;
using SocialPlatformAPI.Infrastructure.Services.Tokens;

namespace SocialPlatformAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
