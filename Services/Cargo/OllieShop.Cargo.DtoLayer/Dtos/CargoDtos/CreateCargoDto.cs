using OllieShop.Cargo.EntityLayer.Enums;

namespace OllieShop.Cargo.DtoLayer.Dtos.CargoDtos
{
    public class CreateCargoDto
    {
        public string TrackingNumber { get; set; } // Takip numarası
        public int OrderId { get; set; } // Sipariş ID'si
        public string UserId { get; set; } // User ID'si
        public CargoStatus Status { get; set; } // Kargo durumu (Enum)
        public DateTime DispatchDate { get; set; } // Gönderim tarihi
        public DateTime? DeliveryDate { get; set; } // Teslimat tarihi (Opsiyonel)
        public string AddressId { get; set; } // Teslimat adresi
    }
}
