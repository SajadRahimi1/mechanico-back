using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace mechanico.Entities;

public class BaseEntity
{
    [Key]
    public ObjectId Id { get; set; }
}