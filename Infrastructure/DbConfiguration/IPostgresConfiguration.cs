using Microsoft.EntityFrameworkCore;

namespace Repositories.DbConfiguration;

public interface IPostgresConfiguration
{
    void Connect(DbContextOptionsBuilder optionsBuilder);
}