namespace Repositories.Entities.Laundry.Enum;

public enum StatusEnum
{
    /// <summary>
    /// The machine is free
    /// </summary>
    Free,
    /// <summary>
    /// The machine is paused
    /// </summary>
    Pause,
    /// <summary>
    /// The machine is currently in use
    /// </summary>
    OnGoing,
    /// <summary>
    /// The machine has finished its cycle
    /// </summary>
    Done,
    /// <summary>
    /// The machine is out of order
    /// </summary>
    TechnicalIssue,
    /// <summary>
    /// The machine has a program error
    /// </summary>
    ProgramError
}