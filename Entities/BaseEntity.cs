using System.ComponentModel.DataAnnotations;
namespace mechanico.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}