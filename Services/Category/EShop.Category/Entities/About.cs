using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Category.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
