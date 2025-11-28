using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Repositories.DbConfiguration;
using System.Reflection;
using System.Text;
using Controllers.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Repositories.User;
using Repositories.User.Repository; // Nécessaire pour les commentaires XML

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

AddLogging(builder);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v0.1",
        Title = "Laundry API",
        Description = "An ASP.NET Core Web API for managing laundry services for the app Laundry."
    });

    // --- AJOUT CRITIQUE : Intégration des commentaires XML ---
    // Cela permet à Swagger d'afficher les descriptions <summary> de vos contrôleurs.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
    // --- Fin de l'ajout ---
});

services.AddDbContext<AppDbContext>(options =>
{
    new PostgresConfiguration(builder.Configuration).Connect(options);
});

services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
        };
    });

services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));
services.AddSingleton<IWriter, Writer>();
services.AddTransient<IPasswordHasher, PasswordHasher>();
services.AddTransient<IJwtToken, JwtToken>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // J'ai modifié le nom ici pour qu'il corresponde à ce que vous aviez
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Laundry API v0.1");
        options.RoutePrefix = string.Empty; // Affiche Swagger à la racine
    });
}

app.UseHttpsRedirection();

// Il vous manque l'autorisation et le mapping des contrôleurs
app.UseAuthorization(); // Assurez-vous d'avoir l'autorisation (même basique)
app.UseAuthentication();
app.MapControllers();   // C'est indispensable pour que vos contrôleurs fonctionnent !

app.Run();

static void AddLogging(WebApplicationBuilder builder)
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