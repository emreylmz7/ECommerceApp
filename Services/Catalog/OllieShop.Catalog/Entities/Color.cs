using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OllieShop.Catalog.Entities
{
    public class Color
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ColorId { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
