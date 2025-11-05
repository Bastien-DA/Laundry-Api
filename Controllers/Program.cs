using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Repositories.DbConfiguration;
using Repositories.LaundryDbContext;

var builder = WebApplication.CreateBuilder(args);

AddLogging(builder);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var postgresConfig = builder.Configuration.GetSection("PostgresSqlConfig").Get<PostgresConfiguration>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(postgresConfig!.ConnectionString, // <--- La seule différence ici
        // Spécifie toujours l'assembly où se trouvent les migrations
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();


app.Run();

static void AddLogging(WebApplicationBuilder builder)
{
    const string serviceName = "Laundry-Api";

    builder.Logging.AddOpenTelemetry(options =>
    {
        options
            .SetResourceBuilder(
                ResourceBuilder.CreateDefault()
                    .AddService(serviceName))
            .AddConsoleExporter();
    });
    builder.Services.AddOpenTelemetry()
        .ConfigureResource(resource => resource.AddService(serviceName))
        .WithTracing(tracing => tracing
            .AddAspNetCoreInstrumentation()
            .AddConsoleExporter())
        .WithMetrics(metrics => metrics
            .AddAspNetCoreInstrumentation()
            .AddConsoleExporter());
}