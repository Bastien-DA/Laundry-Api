using Domain.Laundry;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfiguration;

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
