namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos
{
    public record GetAllOrderLinesDto
    {
        public string ProductName { get; init; }
        public decimal Price { get; init; }
    }
}
