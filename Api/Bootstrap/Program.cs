using Api.Bootstrap;
using Api.Jwt;
using Infrastructure.User;
using Infrastructure.DbConfiguration;
using Infrastructure.User.Repository; // Nécessaire pour les commentaires XML

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

OpenTelemetryConfig.AddOpenTelemetryLogging(builder);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
SwaggerGen.AddSwagger(services);


services.AddDbContext<AppDbContext>(options =>
{
    new PostgresConfiguration(builder.Configuration).Connect(options);
});

Authentication.AddControllerAuthentication(services, builder.Configuration);

services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));
services.AddSingleton<IUserWriter, UserWriter>();
services.AddTransient<IPasswordHasher, PasswordHasher>();
services.AddTransient<IJwtToken, JwtToken>();

var app = builder.Build();

SwaggerGen.AddSwaggerUi(app);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();