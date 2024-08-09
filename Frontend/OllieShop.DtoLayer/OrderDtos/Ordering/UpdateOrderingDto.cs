using OllieShop.DtoLayer.Enums;

namespace OllieShop.DtoLayer.OrderDtos.Ordering
{
    public class UpdateOrderingDto
    {
        public int OrderingId { get; set; }
        public string? UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
    }
}
