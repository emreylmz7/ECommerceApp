using OllieShop.DtoLayer.CatalogDtos.Carousel;

namespace OllieShop.WebUI.Services.CatalogServices.CarouselServices
{
    public interface ICarouselService
    {
        Task<List<ResultCarouselDto>> GetAllCarouselAsync();
        Task<HttpResponseMessage> CreateCarouselAsync(CreateCarouselDto createCarouselDto);
        Task<HttpResponseMessage> UpdateCarouselAsync(UpdateCarouselDto updateCarouselDto);
        Task<HttpResponseMessage> DeleteCarouselAsync(string id);
        Task<GetByIdCarouselDto> GetByIdCarouselAsync(string id);
    }
}
