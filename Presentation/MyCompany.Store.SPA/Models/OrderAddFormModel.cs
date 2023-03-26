namespace MyCompany.Store.SPA.Models
{
    public class OrderAddFormModel
    {
        public string ClientName { get; set; }

        public string AdditionalInfo { get; set; }

        public List<OrderLinesDetailsModel> OrderLines { get; set; }


        public OrderAddFormModel()
        {
            OrderLines = new List<OrderLinesDetailsModel>();
        }
    }
}
