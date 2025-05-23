using AuthModule.Controlllers;
using CompanyModule.Controllers;
using DeanModule.Controllers;
using DocumentModule.Controllers;
using PracticeModule.Service;
using Shared.Extensions;
using StudentModule.Controllers;
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
        services.AddAuthModule(configuration);
        services.AddStudentModule(configuration);
        services.AddCompanyModule(configuration);
        services.AddPracticeModule(configuration);
    }

    public static void UseApplicationModules(this IServiceProvider services)
    {
        services.UseDeanModule();
        services.UseUserModule();
        services.UseDocumentModule();
        services.UseCompanyModule();
        services.UseAuthModule();
        services.UseStudentModule();
        services.UsePracticeModule();
    }
}