using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.LaundryDbContext;

namespace Repositories.DbConfiguration;

public class PostgresConfiguration(IConfigurationRoot configuration) : IPostgresConfiguration
{
    private string? ConnectionString { get; } = configuration.GetSection("PostgresSqlConfig:ConnectionString").Value;

    public void Connect(DbContextOptionsBuilder<AppDbContext> optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString, 
            b => b.MigrationsAssembly("Repositories.LaundryDbContext"));
    }
}