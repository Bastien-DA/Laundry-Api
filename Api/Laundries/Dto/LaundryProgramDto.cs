using Controllers.Machines.Dto;
using Repositories.Laundry.Entity;
using System.ComponentModel.DataAnnotations;

namespace Controllers.Laundries.Dto;

public class LaundryProgramDto
{
    /// <summary>
    /// The name of the program.
    /// </summary>
    [Required]
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
    public required ICollection<MachineDto> Machines { get; set; }


    public LaundryProgramEntity ToEntity()
    {
        return new LaundryProgramEntity
        {
            Name = this.Name,
            Temperature = this.Temperature,
            Speed = this.Speed,
            Duration = this.Duration,
            Machines = [.. this.Machines.Select(m => m.ToEntity())]
        };
    }
}
