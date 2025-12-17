using Domain.User;
using System.ComponentModel.DataAnnotations;

namespace Api.Users.Dto;

public class UserDto
{
    /// <summary>
    /// The Email of the user.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }

    /// <summary>
    /// The password of the user.
    /// </summary>
    [Required]
    [MinLength(6)]
    [MaxLength(50)]
    public required string Password { get; set; }

    public static UserDto ToDto(UserEntity userEntity)
    {
        return new UserDto
        {
            Email = userEntity.Email,
            Password = userEntity.PasswordHash
        };
    }

    public UserEntity ToEntity()
    {
        return new UserEntity
        {
            Email = this.Email,
            PasswordHash = this.Password,
            CreatedAt = DateTime.UtcNow
        };
    }
}