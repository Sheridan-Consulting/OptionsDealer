using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Models.Data;
using Shared.Models.Rules;

namespace Data.Entities;

public class MongoOptionRule : OptionRule
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}