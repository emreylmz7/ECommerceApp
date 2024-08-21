using OllieShop.DtoLayer.Enums;

namespace OllieShop.DtoLayer.CargoDtos.Cargo
{
    public class GetByIdCargoDto
    {
        public int CargoId { get; set; } // Kargo ID'si
        public string TrackingNumber { get; set; } // Takip numarası
        public int OrderId { get; set; } // Sipariş ID'si
        public string UserId { get; set; } // User ID'si
        public CargoStatus Status { get; set; } // Kargo durumu (Enum)
        public DateTime DispatchDate { get; set; } // Gönderim tarihi
        public DateTime? DeliveryDate { get; set; } // Teslimat tarihi (Opsiyonel)
        public string AddressId { get; set; } // Teslimat adresi
    }
}
