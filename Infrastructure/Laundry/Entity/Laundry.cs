using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Laundry.Entity;

public class Laundry
{
    /// <summary>
    /// The unique identifier of the laundry
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } =  Guid.NewGuid();
    
    /// <summary>
    /// The name of the laundry
    /// </summary>
    [MaxLength(50)]
    public required string Name { get; set; }
    
    /// <summary>
    /// The opening hours of the laundry (e.g., "Mon-Fri: 8:00-20:00, Sat-Sun: 9:00-18:00")
    /// </summary>
    [MaxLength(300)]
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
    /// The date and time when the laundry was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// The list of machines available in the laundry
    /// </summary>
    public IEnumerable<Machine>? Machines { get; set; }
}