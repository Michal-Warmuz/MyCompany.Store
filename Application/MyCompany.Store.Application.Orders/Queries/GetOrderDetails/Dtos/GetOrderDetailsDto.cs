namespace MyCompany.Store.Application.Orders.Queries.GetOrderDetails.Dtos
{
    public record GetOrderDetailsDto
    {
        public string ClientName { get; init; }
        public DateTime CreateDate { get; init; }
        public string AdditionalInfo { get; init; }
        public string Status { get; init; }
        public decimal TotalPrice { get; init; }
        public IEnumerable<GetOrderLineDetailsDto> OrderLines { get; init; }

        public GetOrderDetailsDto()
        {

        }

        public GetOrderDetailsDto(GetOrderDetailsDto original, IEnumerable<GetOrderLineDetailsDto> orderLines)
        {
            ClientName = original.ClientName;
            CreateDate = original.CreateDate;
            AdditionalInfo = original.AdditionalInfo;
            Status = original.Status;
            TotalPrice = original.TotalPrice;
            OrderLines = orderLines;
        }
    }
}
