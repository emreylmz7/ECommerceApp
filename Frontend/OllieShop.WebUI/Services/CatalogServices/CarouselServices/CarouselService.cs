using OllieShop.DtoLayer.CatalogDtos.Carousel;

namespace OllieShop.WebUI.Services.CatalogServices.CarouselServices
{
    public class CarouselService : ICarouselService
    {
        private readonly HttpClient _httpClient;

        public CarouselService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCarouselAsync(CreateCarouselDto createCarouselDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCarouselDto>("carousels", createCarouselDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCarouselAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"carousels?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultCarouselDto>> GetAllCarouselAsync()
        {
            var responseMessage = await _httpClient.GetAsync("carousels");
            var carousels = await responseMessage.Content.ReadFromJsonAsync<List<ResultCarouselDto>>();
            return carousels ?? new List<ResultCarouselDto>();
        }

        public async Task<GetByIdCarouselDto> GetByIdCarouselAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"carousels/{id}");
            var carousel = await responseMessage.Content.ReadFromJsonAsync<GetByIdCarouselDto>();
            return carousel;
        }

        public async Task<HttpResponseMessage> UpdateCarouselAsync(UpdateCarouselDto updateCarouselDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCarouselDto>("carousels", updateCarouselDto);
            return responseMessage;
        }
    }
}
