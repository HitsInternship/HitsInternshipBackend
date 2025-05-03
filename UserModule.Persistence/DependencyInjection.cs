using Microsoft.Extensions.DependencyInjection;

namespace UserModule.Persistence
{
    public static class DependencyInjection
    {
        public static void AddUserModulePersistence(this IServiceCollection services)
        {
            services.AddTransient<IDeanMemberRepository, UserModuleRepository>();
        }
    }
}
