namespace OllieShop.Order.Application.Features.Mediator.Results.OrderingResults
{
    namespace OllieShop.Order.Application.Features.Mediator.Results.OrderingResults
    {
        public class GetOrderingStatisticsQueryResult
        {
            public int TotalOrderCount { get; set; } // Toplam Sipariş Sayısı
            public int PendingOrdersCount { get; set; } // Bekleyen Sipariş Sayısı
            public int CompletedOrdersCount { get; set; } // Tamamlanmış Sipariş Sayısı
            public decimal TotalExpenseValue { get; set; } // Toplam Harcama Sayısı
            public decimal AverageOrderValue { get; set; } // Ortalama Sipariş Değeri
            public decimal HighestOrderValue { get; set; } // En Yüksek Sipariş Değeri
            public decimal LowestOrderValue { get; set; } // En Düşük Sipariş Değeri
            public Dictionary<string, int> OrderCountByMonth { get; set; } // Aylara Göre Sipariş Sayısı
            public DateTime FirstOrderDate { get; set; }
            public DateTime LastOrderDate { get; set; } 
        }
    }

}
