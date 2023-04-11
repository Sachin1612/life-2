using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace data.mongo;
public abstract class Document : IDocument
{
    
    public ObjectId Id { get; set; }

    public DateTime CreatedAt => Id.CreationTime;

    public string _myid => Id.ToString();
}