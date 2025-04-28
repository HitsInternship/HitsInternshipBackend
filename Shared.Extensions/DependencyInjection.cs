using Microsoft.Extensions.DependencyInjection;
using Shared.Persistence;

namespace Shared.Extensions;

public static class DependencyInjection
{
    public static void AddSharedModule(this IServiceCollection services)
    {
        services.AddGenericRepositories();
    }
}