using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OllieShop.Catalog.Entities
{
    public class Size
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SizeId { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
