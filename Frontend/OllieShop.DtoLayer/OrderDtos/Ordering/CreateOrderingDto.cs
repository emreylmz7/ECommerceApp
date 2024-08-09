using OllieShop.DtoLayer.Enums;

namespace OllieShop.DtoLayer.OrderDtos.Ordering
{
    public class CreateOrderingDto
    {
        public string? UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
    }
}
