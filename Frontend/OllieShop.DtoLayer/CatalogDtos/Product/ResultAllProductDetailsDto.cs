using OllieShop.DtoLayer.CatalogDtos.Color;
using OllieShop.DtoLayer.CatalogDtos.Size;

namespace OllieShop.DtoLayer.CatalogDtos.Product
{
    public class ResultAllProductDetailsDto
    {
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
        public List<ResultSizeDto>? Sizes { get; set; }
        public List<ResultColorDto>? Colors { get; set; }
        public int TotalStock { get; set; }
    }
}
