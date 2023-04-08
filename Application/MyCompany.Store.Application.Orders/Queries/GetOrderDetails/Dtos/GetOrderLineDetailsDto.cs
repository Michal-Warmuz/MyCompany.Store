namespace MyCompany.Store.Application.Orders.Queries.GetOrderDetails.Dtos
{
    public record GetOrderLineDetailsDto
    {
        public string Product { get; init; }
        public decimal Price { get; init; }
    }
}
