using MediatR;
using Microsoft.AspNetCore.Http;
using OllieShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using OllieShop.Order.Application.Features.Mediator.Results.OrderingResults.OllieShop.Order.Application.Features.Mediator.Results.OrderingResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;
using OllieShop.Order.Domain.Enums;
using System.Security.Claims;

namespace OllieShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingStatisticsQueryHandler : IRequestHandler<GetOrderingStatisticsQuery, GetOrderingStatisticsQueryResult>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetOrderingStatisticsQueryHandler(IRepository<Ordering> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetOrderingStatisticsQueryResult> Handle(GetOrderingStatisticsQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var values = await _repository.GetListByFilterAsync(x => x.UserId == userId);

            var totalOrderCount = values.Count;
            var pendingOrdersCount = values.Count(x => x.Status == OrderStatus.Pending);
            var completedOrdersCount = values.Count(x => x.Status == OrderStatus.Processing);
            var totalExpenseValue = values.Sum(x => x.TotalPrice);
            var averageOrderValue = values.Average(x => x.TotalPrice);
            var highestOrderValue = values.Max(x => x.TotalPrice);
            var lowestOrderValue = values.Min(x => x.TotalPrice);
            var orderCountByMonth = values.GroupBy(x => x.OrderDate.ToString("yyyy-MM"))
                                          .ToDictionary(g => g.Key, g => g.Count());
            var firstOrderDate = values.Min(x => x.OrderDate);
            var lastOrderDate = values.Max(x => x.OrderDate);

            return new GetOrderingStatisticsQueryResult
            {
                TotalOrderCount = totalOrderCount,
                PendingOrdersCount = pendingOrdersCount,
                CompletedOrdersCount = completedOrdersCount,
                TotalExpenseValue = totalExpenseValue,
                AverageOrderValue = averageOrderValue,
                HighestOrderValue = highestOrderValue,
                LowestOrderValue = lowestOrderValue,
                OrderCountByMonth = orderCountByMonth,
                FirstOrderDate = firstOrderDate,
                LastOrderDate = lastOrderDate
            };
        }
    }
}
