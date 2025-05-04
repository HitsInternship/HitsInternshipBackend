using DeanModule.Infrastructure;
using DeanModule.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeanModule.Controllers;

public static class DependencyInjection
{
    public static void AddDeanModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDeanModuleInfrastructure(configuration);
        services.AddDeanModulePersistence();
    }

    public static void UseDeanModule(this WebApplication app)
    {
        app.AddDeanModuleInfrastructure();
    }
}