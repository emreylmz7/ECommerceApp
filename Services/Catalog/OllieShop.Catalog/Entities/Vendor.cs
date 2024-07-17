using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OllieShop.Catalog.Entities
{
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VendorId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
