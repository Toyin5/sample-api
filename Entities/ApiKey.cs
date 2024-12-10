using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleAPI.Entities
{
    public class ApiKey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public required string Key { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public Guid UserId { get; set; }
    }
}
