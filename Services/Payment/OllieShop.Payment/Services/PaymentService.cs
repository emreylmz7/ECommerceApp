using Microsoft.EntityFrameworkCore;
using OllieShop.Payment.Context;
using OllieShop.Payment.Dtos;

namespace OllieShop.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentContext _context;

        public PaymentService(PaymentContext context)
        {
            _context = context;
        }

        public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            var payment = new Entities.Payment
            {
                OrderId = createPaymentDto.OrderId,
                Amount = createPaymentDto.Amount,
                PaymentMethod = createPaymentDto.PaymentMethod,
                PaymentStatus = "Pending", // Başlangıçta "Beklemede" olarak ayarla
                PaymentDate = DateTime.UtcNow
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return new PaymentDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaymentDate = payment.PaymentDate
            };
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return null;
            }

            return new PaymentDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaymentDate = payment.PaymentDate
            };
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByOrderIdAsync(string orderId)
        {
            var payments = await _context.Payments
                .Where(p => p.OrderId == orderId)
                .ToListAsync();

            return payments.Select(payment => new PaymentDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaymentDate = payment.PaymentDate
            });
        }

        public async Task<bool> UpdatePaymentStatusAsync(int id, string status)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return false;
            }

            payment.PaymentStatus = status;
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
