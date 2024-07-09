using OllieShop.Catalog.Dtos.CarouselDtos;

namespace OllieShop.Catalog.Services.CarouselServices
{
    public interface ICarouselService
    {
        Task<List<ResultCarouselDto>> GetAllCarouselAsync();
        Task CreateCarouselAsync(CreateCarouselDto createCarouselDto);
        Task UpdateCarouselAsync(UpdateCarouselDto updateCarouselDto);
        Task DeleteCarouselAsync(string id);
        Task<GetCarouselByIdDto> GetByIdCarouselAsync(string id);
    }
}
