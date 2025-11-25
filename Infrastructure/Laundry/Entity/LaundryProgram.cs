using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Laundry.Entity;

public class LaundryProgram
{
    /// <summary>
    /// The unique identifier for the program.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// The name of the program.
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; set; }
    
    /// <summary>
    /// The temperature setting for the program.
    /// </summary>
    public int Temperature { get; set; }
    
    /// <summary>
    /// The speed setting for the program.
    /// </summary>
    public int Speed { get; set; }
    
    /// <summary>
    /// The duration of the program in minutes.
    /// </summary>
    public int Duration { get; set; }
    
    /// <summary>
    /// The list of machines that support this program.
    /// </summary>
    public required ICollection<Machine> Machines { get; set; }
}