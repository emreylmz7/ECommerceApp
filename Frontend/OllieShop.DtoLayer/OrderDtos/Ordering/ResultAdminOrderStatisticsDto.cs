using OllieShop.DtoLayer.OrderDtos.OrderDetail;

namespace OllieShop.DtoLayer.OrderDtos.Ordering
{
    public class ResultAdminOrderStatisticsDto
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; } 
        public List<ResultOrderDetailDto>? TopSellingProducts { get; set; }
        public int PendingOrdersCount { get; set; } 
        public int CompletedOrdersCount { get; set; } 
        public decimal AverageOrderValue { get; set; } 
        public int OrdersInTransitCount { get; set; } 
        public int OrdersDeliveredCount { get; set; } 
    }
}
