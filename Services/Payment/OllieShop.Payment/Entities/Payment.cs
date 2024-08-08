namespace OllieShop.Payment.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string OrderId { get; set; } // Sipariş ID'si
        public decimal Amount { get; set; } // Ödeme Tutarı
        public string PaymentMethod { get; set; } // Ödeme Yöntemi (örneğin: Kredi Kartı, PayPal, vs.)
        public string PaymentStatus { get; set; } // Ödeme Durumu (örneğin: Başarılı, Başarısız, Beklemede)
        public DateTime PaymentDate { get; set; } // Ödeme Tarihi
    }
}
