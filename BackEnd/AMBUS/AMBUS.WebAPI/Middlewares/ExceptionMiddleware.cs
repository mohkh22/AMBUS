using AMBUS.Application.Exception;
using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try { await _next(context); }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            var statusCode = ex is AppException appEx ? appEx.StatusCode : (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                status = statusCode,
                message = ex.Message,
                detail = "AMBus Internal Error"
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}