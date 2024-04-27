using OllieShop.Catalog.Entities;

namespace OllieShop.Catalog.Dtos.ProductDetailDtos
{
    public class UpdateProductDetailDto
    {
        public string ProductDetailId { get; set; } = null!;
        public string? Description { get; set; }
        public string? Information { get; set; }
        public string? ProductId { get; set; }
    }
}
