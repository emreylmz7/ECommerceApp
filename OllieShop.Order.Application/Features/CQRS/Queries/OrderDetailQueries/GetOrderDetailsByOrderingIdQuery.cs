namespace OllieShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailsByOrderingIdQuery
    {
        public int Id { get; set; }

        public GetOrderDetailsByOrderingIdQuery(int id)
        {
            Id = id;
        }
    }
}
