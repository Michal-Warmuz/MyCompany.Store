using MyCompany.Store.Core.Domain.Orders.Contracts.Base;

namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order, OrderId>
    {
        
    }
}
