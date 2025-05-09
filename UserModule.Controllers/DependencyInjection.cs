using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserModule.Application;
using UserModule.Infrastructure;
using UserModule.Persistence;

namespace UserModule.Controllers
{
    public static class DependencyInjection
    {
        public static void AddUserModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUserModuleInfrastructure(configuration);
            services.AddUserModulePersistence();
            services.AddUserModuleApplication();
        }

        public static void UseUserModule(this IServiceProvider services)
        {
            services.AddUserModuleInfrastructure();
        }
    }
}