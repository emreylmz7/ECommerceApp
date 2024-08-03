using OllieShop.DtoLayer.CatalogDtos.Size;

namespace OllieShop.WebUI.Services.CatalogServices.SizeServices
{
    public class SizeService : ISizeService
    {
        private readonly HttpClient _httpClient;

        public SizeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateSizeAsync(CreateSizeDto createSizeDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateSizeDto>("sizes", createSizeDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteSizeAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"sizes?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultSizeDto>> GetAllSizeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("sizes");
            var sizes = await responseMessage.Content.ReadFromJsonAsync<List<ResultSizeDto>>();
            return sizes ?? new List<ResultSizeDto>();
        }

        public async Task<GetByIdSizeDto> GetByIdSizeAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"sizes/{id}");
            var size = await responseMessage.Content.ReadFromJsonAsync<GetByIdSizeDto>();
            return size;
        }

        public async Task<HttpResponseMessage> UpdateSizeAsync(UpdateSizeDto updateSizeDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateSizeDto>("sizes", updateSizeDto);
            return responseMessage;
        }
    }
}
