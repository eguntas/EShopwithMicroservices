using Eshop.Order.Application.Features.CQRS.Commands.OrderDetailCommand;
using Eshop.Order.Application.Interfaces;
using Eshop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail 
            { 
                ProductAmount = command.ProductAmount,
                ProductName = command.ProductName,
                ProductId = command.ProductId,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingId = command.OrderingId,
                Ordering = command.OrderingId
            });

        }
    }
}
