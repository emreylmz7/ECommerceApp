using MediatR;
using OllieShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using OllieShop.Order.Application.Features.Mediator.Results.OrderingResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderingId = value.OrderingId,
                OrderDate = value.OrderDate,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId
            };
        }
    }
}
