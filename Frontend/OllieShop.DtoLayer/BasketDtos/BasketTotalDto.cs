namespace OllieShop.DtoLayer.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; } = null!;
        public string DiscountCode { get; set; } = null!;
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string Currency { get; set; } = "USD";
        public decimal VATRate { get; set; } = 0.18m; // %18 KDV oranı varsayılan olarak ayarlandı
        public decimal ShippingCost { get; set; } = 15.0m; // Varsayılan kargo ücreti 10 birim olarak ayarlandı

        public decimal TotalPrice
        {
            get => BasketItems?.Sum(x => x.UnitPrice * x.Quantity) ?? 0;
        }

        public decimal TotalPriceWithVAT
        {
            get => TotalPrice * (1 + VATRate);
        }

        public decimal TotalDiscountedPrice
        {
            get => TotalPriceWithVAT * (1 - DiscountRate / 100m);
        }

        public decimal TotalPriceWithVATAndShipping
        {
            get => TotalPriceWithVAT + ShippingCost;
        }

        public decimal TotalDiscountedPriceWithShipping
        {
            get => TotalDiscountedPrice + ShippingCost;
        }
    }
}
