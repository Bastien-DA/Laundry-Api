using Microsoft.EntityFrameworkCore;
using Repositories.Laundry.Entity;
using Repositories.User;

namespace Repositories.DbConfiguration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Laundry.Entity.Laundry> Laundries { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<LaundryStatus> Statuses { get; set; }
    public DbSet<LaundryProgram> Programs { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}
