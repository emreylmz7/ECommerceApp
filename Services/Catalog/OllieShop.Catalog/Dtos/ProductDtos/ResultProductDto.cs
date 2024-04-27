using MongoDB.Bson.Serialization.Attributes;
using OllieShop.Catalog.Entities;

namespace OllieShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CategoryId { get; set; }
        [BsonIgnore]
        public string? ImageUrl { get; set; }
    }
}
