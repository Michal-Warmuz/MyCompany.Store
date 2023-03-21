using Mediator.Commands;

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
