﻿namespace OllieShop.DtoLayer.CargoDtos.CargoDetail
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; } // Kargo detayı ID'si
        public int CargoId { get; set; } // Kargo ID'si
        public string? ProductName { get; set; } // Ürün adı
        public int Quantity { get; set; } // Ürün miktarı
        public decimal UnitPrice { get; set; } // Birim fiyat
        public decimal TotalPrice { get; set; } // Toplam fiyat
    }
}
