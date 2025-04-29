using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeanModule.Infrastructure;

public static class DependencyInjection
{
    public static void AddDeanModuleInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DeanModuleDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("HitsInternship")));
    }

    public static void AddDeanModuleInfrastructure(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<DeanModuleDbContext>();
        dbContext?.Database.Migrate();
    }
}