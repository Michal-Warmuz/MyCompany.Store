namespace MyCompany.Store.Application.Orders.Queries.GetOrderDetails.Dtos
{
    public record GetOrderDetailsDto
    {
        public string ClientName { get; init; }
        public DateTime CreatedDate { get; init; }
        public string AdditionalInfo { get; init; }
        public string Status { get; init; }
        public decimal TotalPrice { get; init; }
        public IEnumerable<GetOrderLineDetailsDto> OrderLines { get; init; }
    }
}
