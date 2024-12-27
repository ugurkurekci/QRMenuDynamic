using Domain.Data;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddDomains(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddDbContext<AppDbContext>();

        return services;
    }

}