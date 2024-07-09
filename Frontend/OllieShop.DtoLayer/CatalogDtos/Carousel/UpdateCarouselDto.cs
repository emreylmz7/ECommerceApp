namespace OllieShop.DtoLayer.CatalogDtos.Carousel

{
    public class UpdateCarouselDto
    {
        public string? CarouselId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
