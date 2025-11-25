using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repositories.Laundry.Entity;
using Repositories.User.Enum;

namespace Repositories.User;

public class PersonEntity
{
    /// <summary>
    /// The unique identifier of the person
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    /// <summary>
    /// The username of the person
    /// </summary>
    [MaxLength(50)]
    public required string Username { get; set; }
    
    /// <summary>
    /// The type of the person
    /// </summary>
    public required PersonTypeEnum PersonType { get; set; }
    
    /// <summary>
    /// The collection of laundries associated with the person
    /// </summary>
    public ICollection<Repositories.Laundry.Entity.Laundry>? Laundries { get; set; }
    
    /// <summary>
    /// The collection of machines associated with the person
    /// </summary>
    public ICollection<Machine>? Machines { get; set; }
}