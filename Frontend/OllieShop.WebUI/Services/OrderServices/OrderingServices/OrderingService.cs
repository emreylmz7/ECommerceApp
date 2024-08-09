using OllieShop.DtoLayer.OrderDtos.Ordering;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Services.CatalogServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateOrderingAsync(CreateOrderingDto createOrderingDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateOrderingDto>("orderings", createOrderingDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteOrderingAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"orderings?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultOrderingDto>> GetAllOrderingAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings");
            var orderings = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();
            return orderings ?? new List<ResultOrderingDto>();
        }

        public async Task<GetByIdOrderingDto> GetByIdOrderingAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/{id}");
            var ordering = await responseMessage.Content.ReadFromJsonAsync<GetByIdOrderingDto>();
            return ordering;
        }

        public async Task<HttpResponseMessage> UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOrderingDto>("orderings", updateOrderingDto);
            return responseMessage;
        }
    }
}
