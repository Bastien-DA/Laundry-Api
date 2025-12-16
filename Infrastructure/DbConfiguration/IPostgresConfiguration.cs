using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfiguration;

public interface IPostgresConfiguration
{
    void Connect(DbContextOptionsBuilder optionsBuilder);
}