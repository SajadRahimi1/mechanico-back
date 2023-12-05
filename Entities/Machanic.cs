namespace mechanico.Entities;

public class Mechanic:BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PlaceName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public List<string> Images { get; set; } = new List<string>();
    public Address? Address { get; set; }
    public List<Category> Categories { get; set; } = new List<Category>();
    public State State { get; set; } = State.OnSubmit;

}

public enum State
{
    Accepted,
    Deny,
    OnSubmit,
    Deleted
}