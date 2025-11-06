using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities.Laundry;

public class LaundryEntity
{
    /// <summary>
    /// The unique identifier of the laundry
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The name of the laundry
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; init; }
    
    /// <summary>
    /// The address of the laundry location
    /// </summary>
    [MaxLength(200)]
    public required string Address { get; init; }
    
    /// <summary>
    /// The latitude of the laundry location
    /// </summary>
    [MaxLength(100)]
    public required string Latitude { get; init; }
    
    /// <summary>
    /// The longitude of the laundry location
    /// </summary>
    [MaxLength(100)]
    public required string Longitude { get; init; }
    
    /// <summary>
    /// The list of machines available in the laundry
    /// </summary>
    public List<MachineEntity>? Machines { get; init; }
}