using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Api.Bootstrap;

public static class OpenTelemetryConfig
{
    public static void AddOpenTelemetryLogging(WebApplicationBuilder builder)
    {
        const string serviceName = "Laundry-Api";

        builder.Logging.ClearProviders();

        // Add OpenTelemetry logging provider by calling the WithLogging extension.
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(r => r.AddService(builder.Environment.ApplicationName))
            .WithLogging(logging => logging
                .AddConsoleExporter());
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(serviceName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation())

            .WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation());
    }
}
