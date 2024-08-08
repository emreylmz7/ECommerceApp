using OllieShop.Order.Domain.Enums;

namespace OllieShop.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public string? UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
