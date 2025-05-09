using DocumentModule.Infrastructure;
using DocumentModule.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentModule.Controllers
{
    public static class DependencyInjection
    {
        public static void AddDocumentModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDocumentModuleInfrastructure(configuration);
            services.AddDocumentModulePersistence();
        }

        public static void UseDocumentModule(this WebApplication app)
        {
            app.AddDocumentModuleInfrastructure();
        }
    }
}
