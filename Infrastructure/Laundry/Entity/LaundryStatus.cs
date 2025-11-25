using System.ComponentModel.DataAnnotations.Schema;
using Repositories.Laundry.Enum;

namespace Repositories.Laundry.Entity;

public class LaundryStatus
{
    /// <summary>
    /// The unique identifier of the status
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// The current status of the machine
    /// </summary>
    public StatusEnum Status { get; set; }
    
    /// <summary>
    /// The DateTime when the status was last updated
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// The foreign key to the current program being executed, if any
    /// </summary>
    public Guid? CurrentProgramId { get; set; }
    
    /// <summary>
    /// The current program being executed by the machine, if any
    /// </summary>
    public LaundryProgram? CurrentProgram { get; set; }
    
    /// <summary>
    /// The machine that has this status
    /// </summary>
    public Machine? Machine { get; set; }
    
    /// <summary>
    /// The foreign key to the machine that has this status
    /// </summary>
    public Guid MachineId { get; set; }
}