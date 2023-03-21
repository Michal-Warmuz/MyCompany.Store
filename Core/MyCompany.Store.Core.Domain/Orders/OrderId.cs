using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders
{
    public class OrderId : TypedIdValueBase
    {
        public OrderId(long value) : base(value)
        {
        }
    }
}