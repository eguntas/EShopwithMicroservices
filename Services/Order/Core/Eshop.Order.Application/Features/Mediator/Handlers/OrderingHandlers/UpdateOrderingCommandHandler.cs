using Eshop.Order.Application.Features.Mediator.Commands;
using Eshop.Order.Application.Interfaces;
using Eshop.Order.Domain.Entities;
using MediatR;

namespace Eshop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetByIdAsync(request.OrderingId);
            if (values != null)
            {
                values.UserId = request.UserId;
                values.TotalPrice = request.TotalPrice;
                values.OrderDate = request.OrderDate;
                await _repository.UpdateAsync(values);
            }
        }
    }
}
