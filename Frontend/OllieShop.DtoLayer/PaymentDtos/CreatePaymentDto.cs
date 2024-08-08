namespace OllieShop.DtoLayer.PaymentDtos
{
    public class CreatePaymentDto
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
