﻿using Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
      
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings").Bind);
        return services;
    }
}
