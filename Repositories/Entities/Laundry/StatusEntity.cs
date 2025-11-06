using Repositories.Entities.Laundry.Enum;

namespace Repositories.Entities.Laundry;

public class StatusEntity
{
    /// <summary>
    /// The unique identifier of the status
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The current status of the machine
    /// </summary>
    public StatusEnum Status { get; init; }
    
    /// <summary>
    /// The DateTime when the status was last updated
    /// </summary>
    public DateTime UpdatedAt { get; init; }
    
    /// <summary>
    /// The current program being executed by the machine, if any
    /// </summary>
    public ProgramEntity? CurrentProgram{ get; init; }
}