using Microsoft.EntityFrameworkCore;
using Repositories.Entities.Laundry;
using Repositories.Entities.User;

namespace Repositories.LaundryDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<LaundryEntity> Laundries { get; set; }
    public DbSet<MachineEntity> Machines { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<ProgramEntity> Programs { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}
