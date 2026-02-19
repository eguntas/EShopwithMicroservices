using Eshop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Eshop.Order.Application.Features.Mediator.Results.OrderingResults;
using Eshop.Order.Application.Interfaces;
using Eshop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _repository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetOrderingsByUserId(request.Id);
            return value.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice,
                OrderingId = x.OrderingId
            }).ToList();
        }
    }
}
