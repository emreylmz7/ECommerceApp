using MediatR;
using OllieShop.Order.Application.Features.CQRS.Results.AddressResults;
using OllieShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using OllieShop.Order.Domain.Enums;

namespace OllieShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }
        public string? UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
    }
}
