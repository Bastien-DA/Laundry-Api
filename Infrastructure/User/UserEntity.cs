using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.User;

[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

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
    public PersonEntity? Person { get; set; }

    /// <summary>
    /// The foreign key to the person associated with the user.
    /// </summary>
    public Guid? PersonId { get; set; }
}