namespace MyCompany.Store.Application.Orders.Commands.EditOrder.Dtos
{
    public record CreateOrderLineDto
    {
        public string ProductName { get; init; }
        public decimal Price { get; init; }
    }
}
