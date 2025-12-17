using Domain.User;

namespace Infrastructure.User.Repository;

public interface IUserWriter
{
    /// <summary>
    /// Asynchronously adds a new user to the data store.
    /// </summary>
    /// <param name="user">The user entity to add. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the add operation.</param>
    /// <returns>The task result contains the unique identifier of the newly added user.</returns>
    public Task<Guid> Add(UserEntity user, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves the unique identifier of a user with the specified user ID.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The task result contains the unique identifier of the user.</returns>
    public Task<Guid> GetUser(Guid userId, CancellationToken cancellationToken);
}