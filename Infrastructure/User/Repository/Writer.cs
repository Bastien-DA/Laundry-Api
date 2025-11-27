using Microsoft.Extensions.Logging;
using Repositories.DbConfiguration;

namespace Repositories.User.Repository;

public class Writer(ILogger<Writer> logger) : IWriter
{
    private readonly AppDbContext _db = new AppDbContextFactory().CreateDbContext([]);

    public async Task<Guid> Add(UserEntity user, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating the user {User}", user);
        await _db.AddAsync(user, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}