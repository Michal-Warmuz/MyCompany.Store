using System.ComponentModel.DataAnnotations;

namespace MyCompany.Store.SPA.Models
{
    public class OrderFormsModel
    {
        public string ClientName { get; set; }

        public string AdditionalInfo { get; set; }

        public List<OrderLinesDetailsModel> OrderLines { get; set; }


        public OrderFormsModel()
        {
            OrderLines = new List<OrderLinesDetailsModel>();
        }
    }
}
