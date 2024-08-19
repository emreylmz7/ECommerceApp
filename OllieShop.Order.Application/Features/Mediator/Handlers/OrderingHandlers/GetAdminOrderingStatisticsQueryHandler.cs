using MediatR;
using OllieShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using OllieShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using OllieShop.Order.Application.Features.Mediator.Results.OrderingResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;
using OllieShop.Order.Domain.Enums;

namespace OllieShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetAdminOrderingStatisticsQueryHandler : IRequestHandler<GetAdminOrderingStatisticsQuery, GetAdminOrderingStatisticsQueryResult>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetAdminOrderingStatisticsQueryHandler(IRepository<Ordering> repository, IRepository<OrderDetail> orderDetailRepository)
        {
            _repository = repository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetAdminOrderingStatisticsQueryResult> Handle(GetAdminOrderingStatisticsQuery request, CancellationToken cancellationToken)
        {
            var orderings = await _repository.GetAllAsync();

            var totalOrders = orderings.Count;
            var pendingOrdersCount = orderings.Count(x => x.Status == OrderStatus.Pending);
            var completedOrdersCount = orderings.Count(x => x.Status == OrderStatus.Processing);
            var ordersInTransitCount = orderings.Count(x => x.Status == OrderStatus.Shipped);
            var ordersDeliveredCount = orderings.Count(x => x.Status == OrderStatus.Delivered);
            var totalSales = orderings.Sum(x => x.TotalPrice);
            var averageOrderValue = orderings.Average(x => x.TotalPrice);

            var orderIds = orderings.Select(x => x.OrderingId).ToList();
            var orderDetails = await _orderDetailRepository.GetListByFilterAsync(od => orderIds.Contains(od.OrderingId));

            var topSellingProducts = orderDetails
                .GroupBy(od => new { od.ProductId, od.ProductName, od.UnitPrice }) 
                .OrderByDescending(g => g.Sum(od => od.Quantity))
                .Select(g => new GetOrderDetailQueryResult
                {
                    OrderDetailId = g.First().OrderDetailId,
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName,
                    UnitPrice = g.Key.UnitPrice,
                    Quantity = g.Sum(od => od.Quantity), 
                    TotalPrice = g.Sum(od => od.TotalPrice), 
                    OrderingId = g.First().OrderingId 
                })
                .Take(5)
                .ToList();


            return new GetAdminOrderingStatisticsQueryResult
            {
                TotalSales = totalSales,
                TotalOrders = totalOrders,
                TopSellingProducts = topSellingProducts,
                PendingOrdersCount = pendingOrdersCount,
                CompletedOrdersCount = completedOrdersCount,
                AverageOrderValue = averageOrderValue,
                OrdersInTransitCount = ordersInTransitCount,
                OrdersDeliveredCount = ordersDeliveredCount
            };
        }
    }
}
