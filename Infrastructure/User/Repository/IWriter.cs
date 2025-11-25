namespace Repositories.User.Repository;

public interface IWriter
{
    public Task Add(UserEntity user, CancellationToken cancellationToken);
}