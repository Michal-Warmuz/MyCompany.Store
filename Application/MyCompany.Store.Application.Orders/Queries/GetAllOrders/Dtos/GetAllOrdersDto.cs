namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos
{
    public record GetAllOrdersDto
    {
        public string ClientName { get; init; }
        public DateTime CreatedDate { get; init; }
        public string AdditionalInfo { get; init; }
        public string Status { get; init; }
        public decimal TotalPrice { get; init; }
        public IEnumerable<GetAllOrderLinesDto> OrderLines { get; init; }
    }
}
