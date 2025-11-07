using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Entities.User;

[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The email address of the user.
    /// </summary>
    [MaxLength(100)]
    public required string Email { get; set; }
    
    /// <summary>
    /// The hashed password of the user.
    /// </summary>
    [MaxLength(255)]
    public required string PasswordHash { get; set; }
    
    /// <summary>
    /// The date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// The person associated with the user.
    /// </summary>
    public required PersonEntity Person { get; set; }
    
    /// <summary>
    /// The foreign key to the person associated with the user.
    /// </summary>
    public Guid PersonId { get; set; }
}