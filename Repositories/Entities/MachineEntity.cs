using Repositories.Entities.Enum;

namespace Repositories.Entities;

public class MachineEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TypeMachineEnum Type { get; set; }
    public StatusEntity StatusEntity { get; set; }
    public List<ProgramEntity> Programs { get; set; }
}