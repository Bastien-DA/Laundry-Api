using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories.DbConfiguration;

public class PostgresConfiguration(IConfigurationRoot configuration) : IPostgresConfiguration
{
    private string? ConnectionString { get; } = configuration.GetSection("PostgresSqlConfig:ConnectionString").Value;

    public void Connect(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString, 
            b => b.MigrationsAssembly("Infrastructure.LaundryDbContext"));
    }
}