using MongoDB.Bson.Serialization.Attributes;

namespace OllieShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductsWithCategoryDto
    {
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
    }
}
