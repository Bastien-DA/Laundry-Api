using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Laundry;
using Services.User.Enum;

namespace Services.User;

public class PersonEntity
{
    /// <summary>
    /// The unique identifier of the person
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The username of the person
    /// </summary>
    [MaxLength(50)]
    public required string Username { get; set; }

    /// <summary>
    /// The type of the person
    /// </summary>
    public required PersonTypeEnumEntity PersonType { get; set; }

    /// <summary>
    /// The collection of laundries associated with the person
    /// </summary>
    public ICollection<LaundryEntity>? Laundries { get; set; }

    /// <summary>
    /// The collection of machines associated with the person
    /// </summary>
    public ICollection<MachineEntity>? Machines { get; set; }
}