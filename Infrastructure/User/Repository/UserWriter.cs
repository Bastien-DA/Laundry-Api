using Domain.User;
using Infrastructure.DbConfiguration;
using Microsoft.Extensions.Logging;
using Repositories.DbConfiguration;

namespace Infrastructure.User.Repository;

public class UserWriter(ILogger<UserWriter> logger) : IUserWriter
{
    private readonly AppDbContext _db = new AppDbContextFactory().CreateDbContext([]);

    public async Task<Guid> Add(UserEntity user, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating the user {User}", user);
        await _db.AddAsync(user, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return user.Id;
    }

    public async Task Delete(Guid userId, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting the user with id {UserId}", userId);
        var user = await _db.Users.FindAsync([userId], cancellationToken);
        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}