using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;

namespace Api.Bootstrap.ExceptionHandler;

public class ExceptionHandlerServiceRegister()
{
    public static void ProblemDetailsExceptionHandlerRegisterService(IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
            };
        });
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddExceptionHandler<UnhandledExceptionHandler>();
    }
}
