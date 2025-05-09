using Shared.Extensions.ErrorHandling;

namespace HitsInternship.Api.Extensions.Middlewares;

public static class DependencyInjection
{
    public static void AddMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}