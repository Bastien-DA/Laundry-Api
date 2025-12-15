using Controllers.Laundries.Dto;
using Controllers.Machines.Dto;
using Repositories.Laundry.Enum;
using Repositories.User;
using Repositories.User.Enum;
using System.ComponentModel.DataAnnotations;

namespace Controllers.Persons.Dto;

public class PersonDto
{
    /// <summary>
    /// The username of the person
    /// </summary>
    [Required]
    public required string Username { get; set; }

    /// <summary>
    /// The type of the person
    /// </summary>
    public PersonTypeEnumDto? PersonType { get; set; } = PersonTypeEnumDto.User;

    /// <summary>
    /// The collection of laundries associated with the person
    /// </summary>
    public ICollection<LaundryDto>? Laundries { get; set; }

    /// <summary>
    /// The collection of machines associated with the person
    /// </summary>
    public ICollection<MachineDto>? Machines { get; set; }

    public PersonEntity ToEntity()
    {
        return new PersonEntity
        {
            Username = this.Username,
            PersonType = this.PersonType.HasValue ? (PersonTypeEnum)this.PersonType.Value : PersonTypeEnum.User,
            Laundries = this.Laundries?.Select(laundryDto => laundryDto.ToEntity()).ToList(),
            Machines = this.Machines?.Select(machineDto => machineDto.ToEntity()).ToList()
        };
    }
}
