namespace OllieShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; } // Kargo detayı ID'si
        public int CargoId { get; set; } // Kargo ID'si
        public string? ProductName { get; set; } // Ürün adı
        public int Quantity { get; set; } // Ürün miktarı
        public decimal UnitPrice { get; set; } // Birim fiyat
        public decimal TotalPrice { get; set; } // Toplam fiyat
        public Cargo Cargo { get; set; } = null!;
    }

}
