namespace Repositories.Entities;

public class LaundryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SchemaName { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}