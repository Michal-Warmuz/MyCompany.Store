namespace MyCompany.Store.SPA.Models
{
    public class OrderDetailsModel
    {
        public string ClientName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AdditionalInfo { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<OrderLinesDetailsModel> OrderLines { get; set; }
    }
}
