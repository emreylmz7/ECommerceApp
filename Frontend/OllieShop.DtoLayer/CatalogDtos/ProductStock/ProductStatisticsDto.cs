namespace OllieShop.DtoLayer.CatalogDtos.ProductStock
{
    public class ProductStatisticsDto
    {
        public int TotalProductCount { get; set; }
        public decimal AverageProductPrice { get; set; }
        public string? MostExpensiveProductName { get; set; }
        public string? CategoryWithMostProducts { get; set; }
    }
}
