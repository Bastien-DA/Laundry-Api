using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repositories.DbConfiguration;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    // La signature doit correspondre à l'interface : prendre string[] en paramètre
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Assure-toi que PostgresConfiguration gère bien la string de connexion ici
        new PostgresConfiguration(configuration).Connect(optionsBuilder);

        return new AppDbContext(optionsBuilder.Options);
    }
}

