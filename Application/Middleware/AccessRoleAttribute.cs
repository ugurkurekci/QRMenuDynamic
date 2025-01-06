using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Domain.Repositories;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Domain.Repositories.Interfaces;

namespace Application.Middleware;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class AccessRoleAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly string[] _requiredRole;

    public AccessRoleAttribute(string[] requiredRole)
    {
        _requiredRole = requiredRole;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();
        var roleRepository = context.HttpContext.RequestServices.GetService<IRoleRepository>();

        if (userRepository == null || roleRepository == null)
        {
            context.Result = new ForbidResult();
            return;
        }

        var userIdClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var user = await userRepository.GetByUserId(userId);
        if (user == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var roles = await roleRepository.GetAllAsync();
        var userRole = roles.FirstOrDefault(r => r.Id == user.RoleId)?.Name;

        if (string.IsNullOrEmpty(userRole) || !_requiredRole.Contains(userRole))
        {
            context.Result = new ForbidResult();
        }

    }
}