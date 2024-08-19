using Eshop.Order.Application.Features.CQRS.Commands.AddressCommands;
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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetaiCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.OrderingId = command.OrderingId;
            value.ProductId = command.ProductId;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(value);
        }
    }
}
