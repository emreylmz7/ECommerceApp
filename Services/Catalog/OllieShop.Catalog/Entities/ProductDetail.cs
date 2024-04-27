using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OllieShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; } = null!;
        public string? Description { get; set; }
        public string? Information { get; set; }
        public string? ProductId { get; set; }
        [BsonIgnore]
        public Product? Product { get; set; }
    }
}
