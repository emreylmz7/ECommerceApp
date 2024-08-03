namespace OllieShop.Catalog.Dtos.ProductStockDtos
{
    public class CreateProductStockDto
    {
        public string ProductId { get; set; } = null!;
        public string ColorId { get; set; } = null!;
        public string SizeId { get; set; } = null!;
        public int Stock { get; set; }
    }
}
