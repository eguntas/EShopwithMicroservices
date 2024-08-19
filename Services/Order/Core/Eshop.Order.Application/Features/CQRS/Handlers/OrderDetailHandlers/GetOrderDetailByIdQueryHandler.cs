using Eshop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Eshop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Eshop.Order.Application.Features.CQRS.Results.AddressResults;
using Eshop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Eshop.Order.Application.Interfaces;
using Eshop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailQueryResult
            {
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                ProductPrice = values.ProductPrice,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                OrderDetailId = values.OrderDetailId,
                OrderingId = values.OrderingId
            };
        }
    }
}
