using System.ComponentModel.DataAnnotations;
using Repositories.Entities.Laundry.Enum;

namespace Repositories.Entities.Laundry;

public class MachineEntity
{
    /// <summary>
    /// The unique identifier of the machine
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The name of the machine
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; init; }
    
    /// <summary>
    /// The type of the machine
    /// </summary>
    public TypeMachineEnum Type { get; init; }
    
    /// <summary>
    /// The laundry to which the machine belongs
    /// </summary>
    public required StatusEntity StatusEntity { get; init; }
    
    /// <summary>
    /// The list of programs supported by the machine
    /// </summary>
    public required List<ProgramEntity> Programs { get; init; }
    
    /// <summary>
    /// The list of laundries that contain this machine
    /// </summary>
    public List<LaundryEntity>? Laundries { get; init; }
}