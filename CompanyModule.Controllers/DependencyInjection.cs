using CompanyModule.Infrastructure;
using CompanyModule.Persistence;
<<<<<<< HEAD
using CompanyModule.Application;
=======
>>>>>>> f7116892c871c6e26e81efd7ffdcd0bb2698baa8
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
<<<<<<< HEAD
            services.AddCompanyModuleApplication();
=======
>>>>>>> f7116892c871c6e26e81efd7ffdcd0bb2698baa8
        }

        public static void UseCompanyModule(this WebApplication app)
        {
            app.AddCompanyModuleInfrastructure();
        }
    }
}
