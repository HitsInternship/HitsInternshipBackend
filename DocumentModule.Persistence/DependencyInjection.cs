﻿using DocumentModule.Contracts.Repositories;
using DocumentModule.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentModule.Persistence
{
    public static class DependencyInjection
    {
        public static void AddDocumentModulePersistence(this IServiceCollection services)
        {
            services.AddTransient<IFileRepository, FileRepository>();
        }
    }
}
