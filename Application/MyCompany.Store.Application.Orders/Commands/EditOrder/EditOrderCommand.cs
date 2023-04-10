using Mediator.Commands;
using MyCompany.Store.Application.Orders.Commands.EditOrder.Dtos;
using MyCompany.Store.Core.Domain.Orders.Enums;

namespace MyCompany.Store.Application.Orders.Commands.EditOrder
{
    public record EditOrderCommand : ICommand
    {
        public long OrderId { get; init; }
        public string ClientName { get; init; }
        public string AdditionalInfo { get; init; }
        public OrderStatus Status { get; init; }
        public IEnumerable<EditOrderLineDto> OrderLines { get; init; }

        public EditOrderCommand(long orderId, string clientName, string additionalInfo, OrderStatus status)
        {
            OrderId = orderId;
            ClientName = clientName;
            AdditionalInfo = additionalInfo;
            Status = status;
        }
    }
}
