using MediatR;
using OllieShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public CreateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        var ordering = new Ordering
        {
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId,
            Status = request.Status,
            AddressId = request.AddressId,
        };

        await _repository.CreateAsync(ordering);
    }
}
