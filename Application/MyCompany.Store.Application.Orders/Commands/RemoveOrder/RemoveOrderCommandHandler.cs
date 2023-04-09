using Mediator.Commands;
using MyCompany.Store.Application.Shared.Commands;
using MyCompany.Store.Application.Shared.Enums;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Application.Orders.Commands.RemoveOrder
{
    internal class RemoveOrderCommandHandler : ICommandHandler<RemoveOrderCommand, CommandResult>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CommandResult> Handle(RemoveOrderCommand command, CancellationToken cancellation)
        {
            var order = await _orderRepository.GetAsync(new OrderId(command.OrderId));

            if(order == null)
            {
                return new CommandResult(ResponseStatus.NotFound, "Order not found");
            }

            try
            {
                order.Remove();
            }
            catch (BusinessRuleValidationException ex)
            {
                return new CommandResult(ResponseStatus.ValidationErrors, ex.Message);
            }

            await _orderRepository.RemoveAsync(new OrderId(command.OrderId));

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
