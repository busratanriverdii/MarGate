using MarGate.Core.Api.Responses.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MarGate.Core.Api.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Console.Error.WriteLine(exception);

        var result = new Result<string>(ResultStatus.Error, "An unexpected error occurred.");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = JsonConvert.SerializeObject(new
        {
            data = result.Data,
            message = result.Message,
            status = result.ResultStatus.ToString()
        });

        return context.Response.WriteAsync(response);
    }
}
