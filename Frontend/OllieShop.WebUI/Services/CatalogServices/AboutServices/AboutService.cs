using OllieShop.DtoLayer.CatalogDtos.About;

namespace OllieShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteAboutAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"abouts?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var responseMessage = await _httpClient.GetAsync("abouts");
            var abouts = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return abouts ?? new List<ResultAboutDto>();
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"abouts/{id}");
            var about = await responseMessage.Content.ReadFromJsonAsync<GetByIdAboutDto>();
            return about;
        }

        public async Task<HttpResponseMessage> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
            return responseMessage;
        }
    }
}
