namespace OllieShop.DtoLayer.PaymentDtos
{
    public class GetByIdPaymentDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
