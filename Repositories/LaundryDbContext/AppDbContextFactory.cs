using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Repositories.DbConfiguration;
using Repositories.Security;

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
        
        var serviceLogger = 
            NullLoggerFactory.Instance.CreateLogger<AesEncryptionService>();
        
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        new PostgresConfiguration(configuration).Connect(optionsBuilder);

        IEncryptionService encryptionService = new AesEncryptionService(configuration, serviceLogger);

        return new AppDbContext(optionsBuilder.Options, encryptionService);
    }
}

