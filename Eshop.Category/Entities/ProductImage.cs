using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Eshop.Category.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageID { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }


    }
}
