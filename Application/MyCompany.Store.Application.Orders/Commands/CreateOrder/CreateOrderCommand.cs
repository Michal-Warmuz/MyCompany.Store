using Mediator.Commands;
using MyCompany.Store.Application.Orders.Commands.CreateOrder.Dtos;

namespace MyCompany.Store.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand : ICommand
    {
        public string AdditionalInfo { get; init; }

        public string ClientName { get; init; }

        public IEnumerable<CreateOrderLineDto> OrderLines { get; init; }
    }
}
