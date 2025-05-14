using DeanModule.Controllers;
using DocumentModule.Controllers;
using Shared.Extensions;
using UserModule.Controllers;

namespace HitsInternship.Api.Extensions;

public static class Modules
{
    public static void AddApplicationModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedModule(configuration);
        services.AddDeanModule(configuration);
        services.AddUserModule(configuration);
        services.AddDocumentModule(configuration);
    }

    public static void UseApplicationModules(this IServiceProvider services)
    {
        services.UseDeanModule();
        services.UseUserModule();
        services.UseDocumentModule();
    }
}