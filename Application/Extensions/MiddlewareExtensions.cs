using Application.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Application.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<AuthenticationMiddleware>();

        return app;
    }
}