using Controllers.Users.Dto;
using Repositories.User;

namespace Controllers.Users.Mapping;

public class UserMapping(IPasswordHasher passwordHasher)
{
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public static UserDto ToDto(UserEntity user)
    {
        return new UserDto
        {
            Email = user.Email,
            Password = user.PasswordHash
        };
    }

    public static UserEntity ToEntity(UserDto dto)
    {
        return new UserEntity
        {
            Email = dto.Email,
            PasswordHash = dto.Password
        };
    }
}