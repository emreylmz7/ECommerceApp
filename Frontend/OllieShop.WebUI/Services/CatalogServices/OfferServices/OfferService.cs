using OllieShop.DtoLayer.CatalogDtos.Offer;

namespace OllieShop.WebUI.Services.CatalogServices.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly HttpClient _httpClient;

        public OfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateOfferDto>("offers", createOfferDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteOfferAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"offers?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("offers");
            var offers = await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDto>>();
            return offers ?? new List<ResultOfferDto>();
        }

        public async Task<GetByIdOfferDto> GetByIdOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"offers/{id}");
            var offer = await responseMessage.Content.ReadFromJsonAsync<GetByIdOfferDto>();
            return offer;
        }

        public async Task<HttpResponseMessage> UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOfferDto>("offers", updateOfferDto);
            return responseMessage;
        }
    }
}
