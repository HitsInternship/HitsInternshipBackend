using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserModule.Application.Handlers;

namespace UserModule.Application
{
    public static class DependencyInjection
    {
        public static void AddUserModuleApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
