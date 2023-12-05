using mechanico.Entities;

namespace mechanico.Dtos;

public class CreateMechanicDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PlaceName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
}