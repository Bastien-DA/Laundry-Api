using Api.Machines.Dto;
using Domain.Laundry;
using System.ComponentModel.DataAnnotations;

namespace Api.Laundries.Dto;

public class LaundryDto
{
    /// <summary>
    /// The name of the laundry
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// The opening hours of the laundry (e.g., "Mon-Fri: 8:00-20:00, Sat-Sun: 9:00-18:00")
    /// </summary>
    [MaxLength(100)]
    public required string Hours { get; set; }

    /// <summary>
    /// The address of the laundry location
    /// </summary>
    [MaxLength(200)]
    public required string Address { get; set; }

    /// <summary>
    /// The latitude of the laundry location
    /// </summary>
    public required decimal Latitude { get; set; }

    /// <summary>
    /// The longitude of the laundry location
    /// </summary>
    public required decimal Longitude { get; set; }

    /// <summary>
    /// The list of machines available in the laundry
    /// </summary>
    public ICollection<MachineDto>? Machines { get; set; }

    public LaundryEntity ToEntity()
    {
        return new LaundryEntity
        {
            Name = this.Name,
            Hours = this.Hours,
            Address = this.Address,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            CreatedAt = DateTime.UtcNow,
            Machines = this.Machines != null
                ? [.. this.Machines.Select(m => m.ToEntity())]
                : new List<MachineEntity>(),
        };
    }
}
