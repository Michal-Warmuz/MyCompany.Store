using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Core.Domain.SeedWork;
using MyCompany.Store.Infrastructure.Web.Essentials.Commands;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;

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
            
            try
            {
                order.Remove();
            }
            catch(BusinessRuleValidationException ex)
            {
                return new CommandResult(ResponseStatus.ValidationErrors, ex.Message);
            }

            _orderRepository.Remove(order);

            await _orderRepository.CommitAsync();

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
