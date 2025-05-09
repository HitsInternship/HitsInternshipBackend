using DocumentModule.Infrastructure.FileStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentModule.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddDocumentModuleInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<DocumentModuleDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("HitsInternship")));

            services.AddScoped<FileStorageContext>(provider =>
            {
                FileStorageSettings settings = new FileStorageSettings();
                configuration.Bind("FileStorageSettings", settings);

                return new FileStorageContext(settings);
            });

        }

        public static void AddDocumentModuleInfrastructure(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<DocumentModuleDbContext>();
            dbContext?.Database.Migrate();
        }
    }
}
