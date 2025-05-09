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
        }

        public static void UseCompanyModule(this WebApplication app)
        {
            app.AddCompanyModuleInfrastructure();
        }
    }
}
