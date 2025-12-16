using Microsoft.OpenApi;

namespace Controllers.Bootstrap;

public static class SwaggerGen
{
    public static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v0.1",
                Title = "Laundry API",
                Description = "An ASP.NET Core Web API for managing laundry services for the app Laundry."
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Entrez votre token JWT. Exemple: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'"
            });

            options.AddSecurityRequirement((document) => new OpenApiSecurityRequirement()
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            });
        });
    }

    public static void AddSwaggerUi(WebApplication app) 
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options =>
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1
            );
            app.UseSwaggerUI(options =>
            {
                // J'ai modifié le nom ici pour qu'il corresponde à ce que vous aviez
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Laundry API v0.1");
                options.RoutePrefix = string.Empty; // Affiche Swagger à la racine
            });
        }
    }
}
