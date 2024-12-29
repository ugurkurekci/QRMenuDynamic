using Core.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JwtSettings _jwtSettings;

    public AuthenticationMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
    {
        _next = next;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        if (context.Request.Path == "/index.html")
        {
            await _next(context);
            return;
        }

        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            await _next(context);
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token) || !ValidateToken(token, out var claimsPrincipal))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        context.User = claimsPrincipal;

        await _next(context);
    }

    private bool ValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
    {
        claimsPrincipal = null;
        try
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };

            claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

            return validatedToken != null;
        }
        catch
        {
            return false;
        }
    }
}
