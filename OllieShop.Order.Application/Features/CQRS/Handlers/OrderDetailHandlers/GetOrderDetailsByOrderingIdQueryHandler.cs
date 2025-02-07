﻿using OllieShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using OllieShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailsByOrderingIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailsByOrderingIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailsByOrderingIdQuery query)
        {
            var values = await _repository.GetListByFilterAsync(x => x.OrderingId == query.Id);
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                OrderingId = x.OrderingId,
                Quantity = x.Quantity,
                TotalPrice = x.TotalPrice,
                UnitPrice = x.UnitPrice
            }).ToList();
        }
    }
}
