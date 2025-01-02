using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;

namespace SocialPlatformAPI.API.Extensions
{
    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = contextFeature.Error.GetType().Name
                        });
                    }
                });
            });
        }
    }
}
