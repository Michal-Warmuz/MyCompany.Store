using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;

namespace MyCompany.Store.Application.Orders.Commands.RemoveOrder
{
    public record RemoveOrderCommand : ICommand
    {
        public long OrderId { get; init; }

        public RemoveOrderCommand(long orderId)
        {
            OrderId = orderId;
        }
    }
}
