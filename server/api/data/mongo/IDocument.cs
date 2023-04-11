using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace data.mongo;
public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }

    DateTime CreatedAt { get; }
}