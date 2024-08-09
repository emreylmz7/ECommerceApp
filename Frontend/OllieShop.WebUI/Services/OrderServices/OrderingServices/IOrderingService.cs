using OllieShop.DtoLayer.OrderDtos.Ordering;

namespace OllieShop.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingDto>> GetAllOrderingAsync();
        Task<HttpResponseMessage> CreateOrderingAsync(CreateOrderingDto createOrderingDto);
        Task<HttpResponseMessage> UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto);
        Task<HttpResponseMessage> DeleteOrderingAsync(string id);
        Task<GetByIdOrderingDto> GetByIdOrderingAsync(string id);
    }
}
