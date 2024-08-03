namespace OllieShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string ColorId { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }  // Optional
        public string Description { get; set; }  // Optional
    }
}
