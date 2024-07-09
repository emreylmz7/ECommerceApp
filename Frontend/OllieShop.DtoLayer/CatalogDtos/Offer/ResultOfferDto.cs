namespace OllieShop.DtoLayer.CatalogDtos.Offer
{
    public class ResultOfferDto
    {
        public string? OfferId { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
