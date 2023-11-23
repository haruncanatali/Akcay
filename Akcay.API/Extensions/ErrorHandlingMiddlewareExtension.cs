using Akcay.API.Middlewares;

namespace Akcay.API.Extensions;

public static class ErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}