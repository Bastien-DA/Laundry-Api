using Microsoft.EntityFrameworkCore;
using Repositories.Laundries;

namespace Repositories.LaundryDbContext;

public class AppDbContext : DbContext
{
    public DbSet<Laundry> Laundries { get; set; }
    private AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("YourConnectionStringHere");
    }
}