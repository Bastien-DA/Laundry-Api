using Controllers.Laundries.Dto;
using Repositories.Laundry.Entity;
using System.ComponentModel.DataAnnotations;

namespace Controllers.Machines.Dto;

public class MachineDto
{
    /// <summary>
    /// The name of the machine
    /// </summary>
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// The type of the machine
    /// </summary>
    [Required]
    public required MachineTypeEnumDto Type { get; set; }

    /// <summary>
    /// The price of using the machine
    /// </summary>
    [Required]
    public decimal Price { get; set; }

    /// <summary>
    /// The current status of the machine
    /// </summary>
    [Required]
    public required LaundryStatusDto LaundryStatus { get; set; }

    /// <summary>
    /// The list of programs supported by the machine
    /// </summary>
    [Required]
    public required ICollection<LaundryProgramDto> Programs { get; set; }

    /// <summary>
    /// The laundry that contains this machine
    /// </summary>
    [Required]
    public required LaundryDto Laundry { get; set; }

    public MachineEntity ToEntity()
    {
        return new MachineEntity
        {
            Name = this.Name,
            Type = (Repositories.Laundry.Enum.MachineTypeEnumEntity)Enum.Parse(typeof(Repositories.Laundry.Enum.MachineTypeEnumEntity), this.Type.ToString()),
            Price = this.Price,
            LaundryStatus = this.LaundryStatus.ToEntity(),
            Programs = [.. this.Programs.Select(p => p.ToEntity())],
            Laundry = this.Laundry.ToEntity(),
        };
    }
}
