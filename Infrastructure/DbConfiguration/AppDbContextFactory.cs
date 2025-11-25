using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repositories.DbConfiguration;

public class AppDbContextFactory
{
    public AppDbContext CreateDbContext()
    {
        // Charge la configuration depuis le projet Api
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        new PostgresConfiguration(configuration).Connect(optionsBuilder);


        return new AppDbContext(optionsBuilder.Options);
    }
}

