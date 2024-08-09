using OllieShop.DtoLayer.OrderDtos.OrderDetail;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;

namespace OllieShop.WebUI.Services.CatalogServices.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderDetailDto>> GetAllOrderDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderdetails");
            var orderDetails = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderDetailDto>>();
            return orderDetails ?? new List<ResultOrderDetailDto>();
        }

        public async Task<HttpResponseMessage> CreateOrderDetailAsync(CreateOrderDetailDto createOrderDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateOrderDetailDto>("orderdetails", createOrderDetailDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> UpdateOrderDetailAsync(UpdateOrderDetailDto updateOrderDetailDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOrderDetailDto>("orderdetails", updateOrderDetailDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteOrderDetailAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"orderdetails/{id}");
            return responseMessage;
        }

        public async Task<GetByIdOrderDetailDto> GetByIdOrderDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderdetails/{id}");
            var orderDetail = await responseMessage.Content.ReadFromJsonAsync<GetByIdOrderDetailDto>();
            return orderDetail;
        }

        public async Task<GetByIdOrderDetailDto> GetOrderDetailsByOrderingIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderdetails/OrderDetailsByOrderingId?id={id}");
            var orderDetails = await responseMessage.Content.ReadFromJsonAsync<GetByIdOrderDetailDto>();
            return orderDetails;
        }
    }
}
