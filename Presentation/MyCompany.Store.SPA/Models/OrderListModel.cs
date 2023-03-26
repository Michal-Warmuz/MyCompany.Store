namespace MyCompany.Store.SPA.Models
{
    public record OrderListModel
    {
        public long OrderId { get; init; }
        public string ClientName { get; init; }
        public DateTime CreatedDate { get; init; }
        public string AdditionalInfo { get; init; }
        public string Status { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
