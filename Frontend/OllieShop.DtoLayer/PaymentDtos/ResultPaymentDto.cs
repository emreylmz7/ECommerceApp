namespace OllieShop.DtoLayer.PaymentDtos
{
    public class ResultPaymentDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
