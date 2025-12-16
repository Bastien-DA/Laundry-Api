using Domain.User;

namespace Infrastructure.User.Repository;

public interface IUserWriter
{
    public Task<Guid> Add(UserEntity user, CancellationToken cancellationToken);
}