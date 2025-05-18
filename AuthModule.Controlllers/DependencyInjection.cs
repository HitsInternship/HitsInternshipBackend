using AuthModel.Infrastructure;
using AuthModel.Service;
using AuthModel.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserModule.Application;

namespace AuthModule.Controllers;

public static class DependencyInjection
{
    public static void AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthModuleInfrastructure(configuration);
        services.AddAuthModuleApplication();
        services.AddScoped<IHashService, HashService>();
    }

    public static void AddAuthModule(this IServiceProvider services)
    {
        services.AddAuthModuleInfrastructure();
    }
}