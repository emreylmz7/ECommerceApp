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
            var ordering = await _repository.GetByIdAsync(request.Id);
            if (ordering == null)
            {
                // Handle the case where the ordering is not found, e.g., throw an exception or return null
                return null; // Or throw new NotFoundException($"Ordering with ID {request.Id} not found.");
            }

            return new GetOrderingByIdQueryResult
            {
                OrderingId = ordering.OrderingId,
                OrderDate = ordering.OrderDate,
                TotalPrice = ordering.TotalPrice,
                UserId = ordering.UserId,
                AddressId = ordering.AddressId,
                Status = ordering.Status,
            };
        }
    }
}
