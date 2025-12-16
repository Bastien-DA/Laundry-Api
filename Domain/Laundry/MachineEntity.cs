using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Laundry.Enum;

namespace Domain.Laundry;

public class MachineEntity
{
    /// <summary>
    /// The unique identifier of the machine
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The name of the machine
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// The type of the machine
    /// </summary>
    public MachineTypeEnumEntity Type { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// The current status of the machine
    /// </summary>
    public required LaundryStatusEntity LaundryStatus { get; set; }

    /// <summary>
    /// The list of programs supported by the machine
    /// </summary>
    public required ICollection<LaundryProgramEntity> Programs { get; set; }

    /// <summary>
    /// The laundry that contains this machine
    /// </summary>
    public required LaundryEntity Laundry { get; set; }

    /// <summary>
    /// The foreign key to the laundry that contains this machine
    /// </summary>
    public Guid LaundryId { get; set; }
}