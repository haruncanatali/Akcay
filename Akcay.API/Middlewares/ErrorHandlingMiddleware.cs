using System.Net;
using System.Text.Json;

namespace Akcay.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = exception switch
        {
            //ValidationException _ => (int)HttpStatusCode.BadRequest, TODO: DÜZENLENECEK
            _ => (int)HttpStatusCode.InternalServerError
        };

        return response.WriteAsync(
            JsonSerializer.Serialize(new List<string>() { exception.Message }));
    }
}