using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserModule.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddUserModuleInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserModuleDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("HitsInternship")));
        }

        public static void AddUserModuleInfrastructure(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<UserModuleDbContext>();
            dbContext?.Database.Migrate();
        }
    }
}
