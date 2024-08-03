namespace OllieShop.DtoLayer.CatalogDtos.ProductStock
{
    public class ResultProductStockDto
    {
        public string ProductStockId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string ColorId { get; set; } = null!;
        public string SizeId { get; set; } = null!;
        public int Stock { get; set; }
    }
}
