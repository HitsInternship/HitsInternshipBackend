﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace PracticeModule.Application
{
    public static class DependencyInjection
    {
        public static void AddPracticeModuleApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
