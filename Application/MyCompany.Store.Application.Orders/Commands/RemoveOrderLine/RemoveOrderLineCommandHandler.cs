using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Core.Domain.SeedWork;
using MyCompany.Store.Infrastructure.Web.Essentials.Commands;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;
using System.Windows.Input;

namespace MyCompany.Store.Application.Orders.Commands.RemoveOrderLine
{
    public class RemoveOrderLineCommandHandler : ICommandHandler<RemoveOrderLineCommand, CommandResult>
    {
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderLineCommandHandler(IOrderLineRepository orderLineRepository, IOrderRepository orderRepository)
        {
            _orderLineRepository = orderLineRepository;
            _orderRepository = orderRepository;
        }

        public async Task<CommandResult> Handle(RemoveOrderLineCommand command, CancellationToken cancellation)
        {
            var order = await _orderRepository.GetAsync(new OrderId(command.OrderId));

            try
            {
                order.RemoveOrderLine(new OrderLineId(command.OrderLineId));
            }
            catch (BusinessRuleValidationException ex)
            {
                return new CommandResult(ResponseStatus.ValidationErrors, ex.Message);
            }

            await _orderLineRepository.RemoveAsync(new OrderLineId(command.OrderLineId));

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
