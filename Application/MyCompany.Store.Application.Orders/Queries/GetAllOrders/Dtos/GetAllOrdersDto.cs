namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos
{
    public record GetAllOrdersDto
    {
        public long OrderId { get; init; }
        public string ClientName { get; init; }
        public DateTime CreateDate { get; init; }
        public string AdditionalInfo { get; init; }
        public string Status { get; init; }
        public decimal TotalPrice { get; init; }

    }
}
