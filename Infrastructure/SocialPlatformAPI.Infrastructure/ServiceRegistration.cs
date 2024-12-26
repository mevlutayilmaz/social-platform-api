using Microsoft.Extensions.DependencyInjection;
using SocialPlatformAPI.Application.Interfaces.Tokens;
using SocialPlatformAPI.Infrastructure.Tokens;

namespace SocialPlatformAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
