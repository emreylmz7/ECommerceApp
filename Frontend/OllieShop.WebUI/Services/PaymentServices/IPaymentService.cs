using OllieShop.DtoLayer.PaymentDtos;

namespace OllieShop.WebUI.Services.PaymentServices
{
    public interface IPaymentService
    {
        Task<HttpResponseMessage> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<HttpResponseMessage> UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto);
        Task<GetByIdPaymentDto> GetByIdPaymentAsync(string id);
        Task<GetByIdPaymentDto> GetByOrderIdPaymentAsync(string id);
    }
}
