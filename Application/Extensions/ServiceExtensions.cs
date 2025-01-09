using Application.Services;
using Core.Services;
using Domain.Data;
using Domain.Repositories;
using Domain.Repositories.Concrete;
using Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        services.AddScoped<JwtTokenService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly);
        });

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

    public static IServiceCollection AddDomains(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IBusinessRepository, BusinessRepository>();
        services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderHandlerRepository, OrderHandlerRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();

        services.AddDbContext<AppDbContext>();

        return services;
    }
}