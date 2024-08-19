using Eshop.Order.Application.Features.CQRS.Results.AddressResults;
using Eshop.Order.Application.Interfaces;
using Eshop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            { 
                AddressId = x.AddressId,
                UserId = x.UserId,  
                Detail = x.Detail,
                District = x.District,
                City = x.City
            }).ToList();
        }
    }
}
