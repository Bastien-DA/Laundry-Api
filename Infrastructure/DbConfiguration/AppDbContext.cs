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

    public DbSet<Laundry.Entity.LaundryEntity> Laundries { get; set; }
    public DbSet<MachineEntity> Machines { get; set; }
    public DbSet<LaundryStatusEntity> Statuses { get; set; }
    public DbSet<LaundryProgramEntity> Programs { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}
