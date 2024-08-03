using OllieShop.DtoLayer.CatalogDtos.Color;

namespace OllieShop.WebUI.Services.CatalogServices.ColorServices
{
    public class ColorService : IColorService
    {
        private readonly HttpClient _httpClient;

        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateColorAsync(CreateColorDto createColorDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateColorDto>("colors", createColorDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteColorAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"colors?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultColorDto>> GetAllColorAsync()
        {
            var responseMessage = await _httpClient.GetAsync("colors");
            var colors = await responseMessage.Content.ReadFromJsonAsync<List<ResultColorDto>>();
            return colors ?? new List<ResultColorDto>();
        }

        public async Task<GetByIdColorDto> GetByIdColorAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"colors/{id}");
            var color = await responseMessage.Content.ReadFromJsonAsync<GetByIdColorDto>();
            return color;
        }

        public async Task<HttpResponseMessage> UpdateColorAsync(UpdateColorDto updateColorDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateColorDto>("colors", updateColorDto);
            return responseMessage;
        }
    }
}
