using Mediator.Commands;
using MyCompany.Store.Application.Shared.Exceptions;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;

namespace MyCompany.Store.Application.Orders.Commands.RemoveOrder
{
    internal class RemoveOrderCommandHandler : ICommandHandler<RemoveOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(RemoveOrderCommand command, CancellationToken cancellation)
        {
            var order = await _orderRepository.GetAsync(new OrderId(command.OrderId));

            if(order == null)
                throw new InvalidCommandException($"Order not found");

            order.Remove();

            await _orderRepository.RemoveAsync(new OrderId(command.OrderId));
        }
    }
}
