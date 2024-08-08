namespace OllieShop.DtoLayer.OrderDtos.OrderDetail
{
    public class ResultOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
