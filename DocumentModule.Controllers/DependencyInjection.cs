using DocumentModule.Infrastructure;
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
        }

        public static void UseDocumentModule(this WebApplication app)
        {
            app.AddDocumentModuleInfrastructure();
        }
    }
}
