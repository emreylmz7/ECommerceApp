namespace OllieShop.DtoLayer.CargoDtos.Cargo
{
    public class CargoStatisticsDto
    {
        public int TotalCargoCount { get; set; } 
        public int DeliveredCargoCount { get; set; } 
        public int PendingDeliveryCargoCount { get; set; } 
        public int CargosDispatchedInLast30Days { get; set; }
    }
}
