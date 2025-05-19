using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelectionModule.Application;
using SelectionModule.Infrastructure;
using SelectionModule.Persistence;

namespace SelectionModule.Controllers;

public static class DependencyInjection
{
    public static void AddSelectionModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSelectionModuleInfrastructure(configuration);
        services.AddSelectionModulePersistence();
        services.AddSelectionModuleApplication();

        /*services.AddSwaggerGen(options =>
        {
            var companyModuleControllersXmlFilename = $"{typeof(DocumentController).Assembly.GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, companyModuleControllersXmlFilename));
        });*/
    }

    public static void UseSelectionModule(this IServiceProvider services)
    {
        services.AddSelectionModuleInfrastructure();
    }
}