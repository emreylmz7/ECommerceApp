namespace OllieShop.DtoLayer.CatalogDtos.ProductStock
{
    public class ProductStocksStatisticsDto
    {
        public int TotalProductStocks { get; set; }
        public int TotalStock { get; set; }
        public int LowStockCount { get; set; }
        public int OutOfStockCount { get; set; }
        public string? MaxStockProductName { get; set; }
    }
}
