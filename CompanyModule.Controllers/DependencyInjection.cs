using CompanyModule.Infrastructure;
using CompanyModule.Persistence;
using CompanyModule.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyModule.Controllers
{
    public static class DependencyInjection
    {
        public static void AddCompanyModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCompanyModuleInfrastructure(configuration);
            services.AddCompanyModulePersistence();
            services.AddCompanyModuleApplication();

            services.AddSwaggerGen(options =>
            {
                var companyModuleControllersXmlFilename = $"{typeof(CompanyController).Assembly.GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, companyModuleControllersXmlFilename));
            });
        }

        public static void UseCompanyModule(this WebApplication app)
        {
            app.AddCompanyModuleInfrastructure();
        }
    }
}
