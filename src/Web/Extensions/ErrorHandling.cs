using Domain.Exceptions;
using System.Text.Json;

namespace Web.Middleware;

internal sealed class ErrorHandling
: IMiddleware 
{ 
    private readonly ILogger<ErrorHandling> _logger;

    public ErrorHandling(ILogger<ErrorHandling> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next){
        try{
            await next(httpContext);
        }catch(Exception exception){
            _logger.LogError(exception, exception.Message);
            await HandleExceptionAsync(httpContext, exception);
        }        
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception){
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode  = exception switch {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var respose= new { error = exception.Message};
        await httpContext.Response.WriteAsync(
            JsonSerializer.Serialize(respose));
    }
}