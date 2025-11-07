using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repositories.Entities.Laundry.Enum;

namespace Repositories.Entities.Laundry;

public class MachineEntity
{
    /// <summary>
    /// The unique identifier of the machine
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    /// <summary>
    /// The name of the machine
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; set; }
    
    /// <summary>
    /// The type of the machine
    /// </summary>
    public TypeMachineEnum Type { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    
    /// <summary>
    /// The current status of the machine
    /// </summary>
    public required StatusEntity Status { get; set; }
    
    /// <summary>
    /// The list of programs supported by the machine
    /// </summary>
    public required ICollection<ProgramEntity> Programs { get; set; }
    
    /// <summary>
    /// The laundry that contains this machine
    /// </summary>
    public LaundryEntity? Laundry { get; set; }
    
    /// <summary>
    /// The foreign key to the laundry that contains this machine
    /// </summary>
    public Guid LaundryId { get; set; }
}