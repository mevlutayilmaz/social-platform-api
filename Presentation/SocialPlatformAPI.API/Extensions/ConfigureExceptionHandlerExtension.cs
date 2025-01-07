using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using SendGrid.Helpers.Errors.Model;
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
                    IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            BadRequestException => StatusCodes.Status400BadRequest,
                            NotFoundException => StatusCodes.Status404NotFound,
                            ValidationException => StatusCodes.Status422UnprocessableEntity,
                            UnauthorizedException => StatusCodes.Status401Unauthorized,
                            ForbiddenException => StatusCodes.Status403Forbidden,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        await context.Response.WriteAsJsonAsync(new
                        {
                            Title = contextFeature.Error.GetType().Name,
                            Errors = contextFeature.Error is ValidationException validationException
                                ? validationException.Errors.Select(e => e.ErrorMessage).ToList()
                                : new List<string>() { contextFeature.Error.Message }
                        });
                    }
                });
            });
        }
    }
}
