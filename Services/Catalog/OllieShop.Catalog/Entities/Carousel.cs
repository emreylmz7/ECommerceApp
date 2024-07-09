using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OllieShop.Catalog.Entities
{
    public class Carousel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CarouselId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
