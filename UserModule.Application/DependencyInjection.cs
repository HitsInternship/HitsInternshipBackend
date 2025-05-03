using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Contracts.Repositories;
using UserModule.Persistence.Repositories;

namespace UserModule.Application
{
    public static class DependencyInjection
    {
        public static void AddUserModuleApplication(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
        }
    }
}
