using OllieShop.Order.Domain.Enums;

namespace OllieShop.Order.Application.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingsByUserQueryResult
    {
        public int OrderingId { get; set; }
        public string? UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
    }
}
