using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyModule.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCompanyModuleInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompanyModuleDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("HitsInternship")));
        }

        public static void AddCompanyModuleInfrastructure(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<CompanyModuleDbContext>();
            dbContext?.Database.Migrate();
        }
    }
}
