namespace OllieShop.DtoLayer.CatalogDtos.ProductDetail
{
    public class UpdateProductDetailDto
    {
        public string ProductDetailId { get; set; } = null!;
        public string? Description { get; set; }
        public string? Information { get; set; }
        public string? ProductId { get; set; }
    }
}
