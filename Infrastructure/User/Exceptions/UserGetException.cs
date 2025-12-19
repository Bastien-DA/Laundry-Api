using Common.Exceptions;

namespace Infrastructure.User.Exceptions;

public class UserGetException() : StatusCodeException(404, "User Not Found", "The user is not found")
{
}
