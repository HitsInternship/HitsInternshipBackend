﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DeanModule.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config
            => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(typeof(DeanModuleMappingProfile));
        
    }
}