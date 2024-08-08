using OllieShop.Payment.Dtos;

namespace OllieShop.Payment.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<PaymentDto> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentDto>> GetPaymentsByOrderIdAsync(string orderId);
        Task<bool> UpdatePaymentStatusAsync(int id, string status);
    }

}
