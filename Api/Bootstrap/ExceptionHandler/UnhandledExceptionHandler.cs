using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Bootstrap.ExceptionHandler;

public class UnhandledExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Type = exception.GetType().Name,
                Status = 500,
                Title = "An unexpected error occurred.",
                Detail = exception.Message
            }
        };
        await problemDetailsService.TryWriteAsync(problemDetailsContext);
        return true;
    }
}
