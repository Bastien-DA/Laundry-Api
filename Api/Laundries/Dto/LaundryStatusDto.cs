using Api.Machines.Dto;
using Domain.Laundry;
using Domain.Laundry.Enum;

namespace Api.Laundries.Dto;

public class LaundryStatusDto
{
    /// <summary>
    /// The current status of the machine
    /// </summary>
    public MachineStatusEnumDto Status { get; set; }

    /// <summary>
    /// The Current program being executed by the machine
    /// </summary>
    public LaundryProgramDto? CurrentProgram { get; set; }

    /// <summary>
    /// The machine that has this status
    /// </summary>
    public MachineDto? Machine { get; set; }

    public LaundryStatusEntity ToEntity()
    {
        return new LaundryStatusEntity
        {
            Status = Enum.Parse<MachineStatusEnumEntity>(this.Status.ToString()),
            CurrentProgram = this.CurrentProgram?.ToEntity(),
            Machine = this.Machine?.ToEntity(),
        };
    }
}
