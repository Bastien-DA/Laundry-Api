using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities.Laundry;

public class ProgramEntity
{
    /// <summary>
    /// The unique identifier for the program.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The name of the program.
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; init; }
    
    /// <summary>
    /// The temperature setting for the program.
    /// </summary>
    public int Temperature { get; init; }
    
    /// <summary>
    /// The speed setting for the program.
    /// </summary>
    public int Speed { get; init; }
    
    /// <summary>
    /// The duration of the program in minutes.
    /// </summary>
    public int Duration { get; init; }
    
    /// <summary>
    /// The list of machines that support this program.
    /// </summary>
    public required List<MachineEntity> Machines { get; init; }
    
}