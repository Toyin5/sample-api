using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleAPI.Entities
{
    public class File
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string _id { get; set; }
        public required string Name { get; set; }
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public Guid UserId { get; set; }
    }
}
