namespace OllieShop.DtoLayer.CatalogDtos.ProductStock
{
    public class ResultProductStockWithDetailsDto
    {
        public string ProductStockId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string? ProductName { get; set; }
        public string ColorId { get; set; } = null!;
        public string? Color { get; set; }
        public string SizeId { get; set; } = null!;
        public string? Size { get; set; }
        public int Stock { get; set; }
    }
}
