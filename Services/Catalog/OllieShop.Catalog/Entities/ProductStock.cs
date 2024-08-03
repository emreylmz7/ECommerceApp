using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OllieShop.Catalog.Entities
{
    public class ProductStock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductStockId { get; set; } = null!;

        public string ProductId { get; set; } = null!;
        [BsonIgnore]
        public Product? Product { get; set; }

        public string ColorId { get; set; } = null!;
        [BsonIgnore]
        public Color? Color { get; set; }

        public string SizeId { get; set; } = null!;
        [BsonIgnore]
        public Size? Size { get; set; }
        public int Stock { get; set; }
    }
}
