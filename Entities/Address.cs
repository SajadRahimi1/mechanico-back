namespace mechanico.Entities;

public class Address : BaseEntity
{
    public Guid MechanicId { get; set; } 
    public Mechanic? Mechanic { get; set; }
    public string? Province { get; set; }
    public string? City { get; set; }
    public string? Neighbourhood { get; set; }
    public string? Street { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    
}