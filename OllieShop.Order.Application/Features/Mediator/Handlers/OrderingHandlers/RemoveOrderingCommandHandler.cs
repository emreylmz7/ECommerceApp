using MediatR;
using OllieShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository, IRepository<OrderDetail> orderDetailRepository)
        {
            _repository = repository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            // Ordering entity'sini id ile al
            var ordering = await _repository.GetByIdAsync(request.Id);

            if (ordering == null)
            {
                // Ordering bulunamazsa, uygun bir hata mesajı veya handling mekanizması kullanılabilir.
                throw new Exception("Order not found.");
            }

            // OrderDetail'leri al ve sil
            var orderDetails = (await _orderDetailRepository.GetAllAsync()).Where(x => x.OrderingId == ordering.OrderingId).ToList();

            foreach (var detail in orderDetails)
            {
                await _orderDetailRepository.DeleteAsync(detail);
            }

            // Ordering'i sil
            await _repository.DeleteAsync(ordering);
        }
    }
}
