using OllieShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.ProductId = command.ProductId;
            values.ProductName = command.ProductName;
            values.UnitPrice = command.UnitPrice;
            values.Quantity = command.Quantity;
            values.TotalPrice = command.TotalPrice;
            values.OrderingId = command.OrderingId;

            await _repository.UpdateAsync(values);
        }
    }
}