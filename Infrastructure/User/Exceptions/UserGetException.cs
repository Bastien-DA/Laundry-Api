using Common.Exceptions;

namespace Infrastructure.User.Exceptions;

public class UserGetException(string detail) : StatusCodeException(404, "User Not Found", detail)
{
}
