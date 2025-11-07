using System.ComponentModel.DataAnnotations;

namespace Controllers.Users.Dto;

public class UserDto
{
    /// <summary>
    /// The Email of the user.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    
    /// <summary>
    /// The password of the user.
    /// </summary>
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}