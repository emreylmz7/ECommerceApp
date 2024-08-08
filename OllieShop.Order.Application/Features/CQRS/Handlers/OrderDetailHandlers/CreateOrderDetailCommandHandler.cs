using OllieShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                TotalPrice = command.TotalPrice,
                OrderingId = command.OrderingId,
                Quantity = command.Quantity,
                UnitPrice = command.UnitPrice,
            });
        }
    }
}
