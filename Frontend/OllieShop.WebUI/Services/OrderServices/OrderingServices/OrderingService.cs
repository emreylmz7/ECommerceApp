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
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteOrderingAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"orderings?id={id}");
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<List<ResultOrderingDto>> GetAllOrderingAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var orderings = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();
                return orderings ?? new List<ResultOrderingDto>();
            }
            return new List<ResultOrderingDto>();
        }

        public async Task<GetByIdOrderingDto> GetByIdOrderingAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var ordering = await responseMessage.Content.ReadFromJsonAsync<GetByIdOrderingDto>();
                return ordering ?? new GetByIdOrderingDto();
            }
            return new GetByIdOrderingDto();
        }

        public async Task<HttpResponseMessage> UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOrderingDto>("orderings", updateOrderingDto);
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<int> GetTotalOrdersCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var orderings = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();
                return orderings?.Count() ?? 0;
            }
            return 0;
        }

        public async Task<List<ResultOrderingDto>> GetOrderingsByUserAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings/GetOrderingsByUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var orderings = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();
                return orderings ?? new List<ResultOrderingDto>();
            }
            return new List<ResultOrderingDto>();
        }

        public async Task<ResultOrderingStatisticsDto> GetOrderingStatisticsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings/GetOrderStatistics");
            if (responseMessage.IsSuccessStatusCode)
            {
                var orderings = await responseMessage.Content.ReadFromJsonAsync<ResultOrderingStatisticsDto>();
                return orderings ?? new ResultOrderingStatisticsDto();
            }
            return new ResultOrderingStatisticsDto();
        }
    }
}
