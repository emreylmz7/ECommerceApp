using OllieShop.DtoLayer.OrderDtos.Ordering;

namespace OllieShop.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingDto>> GetAllOrderingAsync();
        Task<List<ResultOrderingDto>> GetOrderingsByUserAsync();
        Task<HttpResponseMessage> CreateOrderingAsync(CreateOrderingDto createOrderingDto);
        Task<HttpResponseMessage> UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto);
        Task<HttpResponseMessage> DeleteOrderingAsync(string id);
        Task<GetByIdOrderingDto> GetByIdOrderingAsync(string id);
        Task<int> GetTotalOrdersCountAsync();
        Task<ResultOrderingStatisticsDto> GetOrderingStatisticsAsync();
        Task<ResultAdminOrderStatisticsDto> GetAdminOrderingStatisticsAsync();
    }
}
