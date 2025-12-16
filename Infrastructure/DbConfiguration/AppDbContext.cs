using Microsoft.EntityFrameworkCore;
using Services.Laundry;
using Services.User;

namespace Repositories.DbConfiguration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<LaundryEntity> Laundries { get; set; }
    public DbSet<MachineEntity> Machines { get; set; }
    public DbSet<LaundryStatusEntity> Statuses { get; set; }
    public DbSet<LaundryProgramEntity> Programs { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}
