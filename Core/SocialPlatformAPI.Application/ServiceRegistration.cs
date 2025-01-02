using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialPlatformAPI.Application.Beheviors;
using System.Reflection;

namespace SocialPlatformAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
