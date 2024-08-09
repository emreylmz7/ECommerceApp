using OllieShop.DtoLayer.OrderDtos.OrderDetail;

namespace OllieShop.WebUI.Services.OrderServices.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<List<ResultOrderDetailDto>> GetAllOrderDetailAsync();
        Task<HttpResponseMessage> CreateOrderDetailAsync(CreateOrderDetailDto createOrderDetailDto);
        Task<HttpResponseMessage> UpdateOrderDetailAsync(UpdateOrderDetailDto updateOrderDetailDto);
        Task<HttpResponseMessage> DeleteOrderDetailAsync(string id);
        Task<GetByIdOrderDetailDto> GetByIdOrderDetailAsync(string id);
        Task<GetByIdOrderDetailDto> GetOrderDetailsByOrderingIdAsync(string id);
    }
}
