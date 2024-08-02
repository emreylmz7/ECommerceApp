namespace OllieShop.DtoLayer.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string Currency { get; set; } = "USD";

        public decimal TotalPrice
        {
            get => BasketItems?.Sum(x => x.UnitPrice * x.Quantity) ?? 0;
        }

        public decimal TotalDiscountedPrice
        {
            get => TotalPrice * (1 - DiscountRate / 100m);
        }
    }
}
