namespace mechanico.Entities;

public class Mechanic:BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PlaceName { get; set; }
    public List<string> Images { get; set; } = new List<string>();
    public Address Address { get; set; }
}