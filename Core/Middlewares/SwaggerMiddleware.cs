using Microsoft.AspNetCore.Http;

namespace Core.Middlewares;

public class SwaggerMiddleware
{

    private readonly RequestDelegate _next;
    public SwaggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // eğer swagger sayfasına giriliyorsa
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            // eğer token yoksa
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                // 401 hatası döndür
                context.Response.StatusCode = 401;
                return;
            }
        }
        // diğer middleware'a devam et
        await _next(context);
    }


}