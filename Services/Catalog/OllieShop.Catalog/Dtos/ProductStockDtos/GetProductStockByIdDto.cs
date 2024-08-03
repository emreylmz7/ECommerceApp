namespace OllieShop.Catalog.Dtos.ProductStockDtos
{
    public class GetProductStockByIdDto
    {
        public string ProductStockId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ColorId { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string SizeId { get; set; } = null!;
        public string Size { get; set; } = null!;
        public int Stock { get; set; }
    }
}
