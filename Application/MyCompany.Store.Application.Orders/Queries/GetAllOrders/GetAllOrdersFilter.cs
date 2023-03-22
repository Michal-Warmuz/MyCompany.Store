using MyCompany.Store.Application.Orders.Enums;

namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders
{
    public struct GetAllOrdersFilter
    {
        public DateTime? CreatedDate { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
