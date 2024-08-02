namespace OllieShop.DtoLayer.BasketDtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }  // Optional
        public string Description { get; set; }  // Optional
    }
}
