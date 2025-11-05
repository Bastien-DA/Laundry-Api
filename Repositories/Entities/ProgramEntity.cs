namespace Repositories.Entities;

public class ProgramEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Temperature { get; set; }
    public int Speed { get; set; }
    public int Duration { get; set; }
    public List<MachineEntity> Machines { get; set; }
    
}