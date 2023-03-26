using System.ComponentModel.DataAnnotations;

namespace MyCompany.Store.SPA.Models
{
    public class OrderLinesDetailsModel
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

    }
}
