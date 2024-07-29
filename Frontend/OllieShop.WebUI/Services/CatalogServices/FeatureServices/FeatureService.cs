using OllieShop.DtoLayer.CatalogDtos.Feature;

namespace OllieShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"features?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var responseMessage = await _httpClient.GetAsync("features");
            var features = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();
            return features ?? new List<ResultFeatureDto>();
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"features/{id}");
            var feature = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureDto>();
            return feature;
        }

        public async Task<HttpResponseMessage> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
            return responseMessage;
        }
    }
}
