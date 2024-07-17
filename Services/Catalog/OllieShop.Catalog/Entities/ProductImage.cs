using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace OllieShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImagesId { get; set; } = null!;

        [Required]
        [MinLength(4, ErrorMessage = "You must provide at least 4 images.")]
        [MaxLength(10, ErrorMessage = "You can provide a maximum of 10 images.")]
        public List<string> Images { get; set; } = new List<string>();

        public string? ProductId { get; set; }
        [BsonIgnore]
        public Product? Product { get; set; }
    }
}
