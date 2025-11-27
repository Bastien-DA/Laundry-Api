namespace Repositories.User.Repository;

public interface IWriter
{
    public Task<Guid> Add(UserEntity user, CancellationToken cancellationToken);
}