using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleAPI.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public Guid UserId { get; set; } = Guid.NewGuid();
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }
    }
}
