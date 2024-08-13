using MediatR;
using Microsoft.AspNetCore.Http;
using OllieShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using OllieShop.Order.Application.Features.Mediator.Results.OrderingResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;
using System.Security.Claims;

namespace OllieShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingsByUserQueryHandler : IRequestHandler<GetOrderingsByUserQuery, List<GetOrderingsByUserQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetOrderingsByUserQueryHandler(IRepository<Ordering> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetOrderingsByUserQueryResult>> Handle(GetOrderingsByUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var values = await _repository.GetListByFilterAsync(x => x.UserId == userId);
            return values.Select(ordering => new GetOrderingsByUserQueryResult
            {
                OrderingId = ordering.OrderingId,
                OrderDate = ordering.OrderDate,
                TotalPrice = ordering.TotalPrice,
                UserId = ordering.UserId,
                AddressId = ordering.AddressId,
                Status = ordering.Status,

            }).ToList();
        }
    }
}
