using Microsoft.AspNetCore.Http;
using Shared.Extensions.ErrorHandling.Error;
using System.Text.Json;

namespace Shared.Extensions.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ErrorException.ErrorException exception)
            {
                await HandleExceptionAsync(context, exception);
            }
            catch (ErrorCollectionException exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, ErrorException.ErrorException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.status;

            var result = JsonSerializer.Serialize(new ErrorResponse(exception.status, exception.message));
            return context.Response.WriteAsync(result);
        }

        private Task HandleExceptionAsync(HttpContext context, ErrorCollectionException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.status;

            var result = JsonSerializer.Serialize(new ErrorCollectionResponse(exception.status, exception.errors));
            return context.Response.WriteAsync(result);
        }
    }
}
