
using System.ComponentModel.DataAnnotations;
using data.mongo;

namespace models;

[BsonCollection("users")]
public class User : Document
{   
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public double Mobile { get; set; }
    public DateTime? Dob { get; set; }
    public string Email { get; set; } = null!;
    public string Profile { get; set; } = null!;
}