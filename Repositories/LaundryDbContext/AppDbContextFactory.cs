using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Repositories.DbConfiguration;

namespace Repositories.LaundryDbContext;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Charge la configuration depuis le projet Controllers
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Controllers"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        new PostgresConfiguration(configuration).Connect(optionsBuilder);


        return new AppDbContext(optionsBuilder.Options);
    }
}

