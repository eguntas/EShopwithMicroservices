using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Category.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandID { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
