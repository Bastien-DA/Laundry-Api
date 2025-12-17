using Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Bootstrap.ExceptionHandler;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not StatusCodeException statusCodeException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = statusCodeException.StatusCode ?? 500;
        
        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Type = exception.GetType().Name,
                Title = statusCodeException.Title,
                Detail = statusCodeException.Detail,
                Status = statusCodeException.StatusCode,
            }
        };
        
        await problemDetailsService.TryWriteAsync(problemDetailsContext);
        return true;
    }
}
