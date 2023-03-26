using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;

namespace MyCompany.Store.Application.Orders.Commands.RemoveOrderLine
{
    public record RemoveOrderLineCommand : ICommand
    {
        public long OrderLineId { get; init; }
        public long OrderId { get; init; }

        public RemoveOrderLineCommand(long orderLineId, long orderId)
        {
            OrderLineId = orderLineId;
            OrderId = orderId;
        }
    }
}
