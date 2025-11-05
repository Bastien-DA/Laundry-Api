using Repositories.Entities.Enum;

namespace Repositories.Entities;

public class StatusEntity
{
    public Guid Id { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ProgramEntity? CurrentProgram{ get; set; }
}