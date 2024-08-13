using MediatR;
using OllieShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace OllieShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingsByUserQuery : IRequest<List<GetOrderingsByUserQueryResult>>
    {
    }
}
