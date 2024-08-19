using OllieShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace OllieShop.Order.Application.Features.Mediator.Results.OrderingResults
{
    public class GetAdminOrderingStatisticsQueryResult
    {
        public decimal TotalSales { get; set; } // Toplam satış miktarı
        public int TotalOrders { get; set; } // Toplam sipariş sayısı
        public List<GetOrderDetailQueryResult>? TopSellingProducts { get; set; } // En çok satan ürünlerin listesi
        public int PendingOrdersCount { get; set; } // Bekleyen sipariş sayısı
        public int CompletedOrdersCount { get; set; } // Tamamlanmış sipariş sayısı
        public decimal AverageOrderValue { get; set; } // Ortalama sipariş değeri
        public int OrdersInTransitCount { get; set; } // Yolda olan sipariş sayısı
        public int OrdersDeliveredCount { get; set; } // Teslim edilen sipariş sayısı
    }
}
