namespace OllieShop.Cargo.EntityLayer.Enums
{
    public enum CargoStatus
    {
        Created,       // Kargo oluşturuldu
        Dispatched,    // Kargo gönderildi
        InTransit,     // Kargo yolda
        Delivered,     // Kargo teslim edildi
        Cancelled      // Kargo iptal edildi
    }
}
