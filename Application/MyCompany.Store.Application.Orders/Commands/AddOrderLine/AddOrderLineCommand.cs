using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;
using Newtonsoft.Json;

namespace MyCompany.Store.Application.Orders.Commands.AddOrderLine
{
    public record AddOrderLineCommand : ICommand
    {
        public string ProductName { get; init; }
        public decimal Price { get; init; }
        public long OrderId { get; init; }


        public AddOrderLineCommand(string productName, decimal price, long orderId)
        {
            ProductName = productName;
            Price = price;
            OrderId = orderId;
        }
    }
}
