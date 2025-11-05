using Microsoft.EntityFrameworkCore;
using Repositories.DbConfiguration;
using Repositories.Laundries;

namespace Repositories.LaundryDbContext;

public class AppDbContext : DbContext
{
    public DbSet<Laundry> Laundries { get; set; }
    private readonly PostgresConfiguration _postgresConfiguration;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_postgresConfiguration.ConnectionString);
    }
}