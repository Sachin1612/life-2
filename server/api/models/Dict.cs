
using System.ComponentModel.DataAnnotations;
using data.mongo;

namespace models;

[BsonCollection("dictionary")]
public class Dict : Document
{   
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public bool isActive { get; set; } = false;
}