using Microsoft.EntityFrameworkCore;
using Repositories.LaundryDbContext;

namespace Repositories.DbConfiguration;

public interface IPostgresConfiguration
{
    void Connect(DbContextOptionsBuilder<AppDbContext> optionsBuilder);
}