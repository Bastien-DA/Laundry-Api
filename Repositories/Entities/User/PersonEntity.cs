using System.ComponentModel.DataAnnotations;
using Repositories.Entities.Laundry;
using Repositories.Entities.User.Enum;

namespace Repositories.Entities.User;

public class PersonEntity
{
    /// <summary>
    /// The unique identifier of the person
    /// </summary>
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
    public ICollection<LaundryEntity>? Laundries { get; set; }
    
    /// <summary>
    /// The collection of machines associated with the person
    /// </summary>
    public ICollection<MachineEntity>? Machines { get; set; }
}