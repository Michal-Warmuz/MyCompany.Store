namespace MyCompany.Store.Application.Orders.Commands.CreateOrder.Dtos
{
    public record CreateOrderLineDto
    {
        public string ProductName { get; init; }
        public decimal Price { get; init; }
    }
}
