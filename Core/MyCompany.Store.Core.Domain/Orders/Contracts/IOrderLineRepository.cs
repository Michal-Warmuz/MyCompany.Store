namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IOrderLineRepository : IAsyncRepository<OrderLine, OrderLineId>
    {

    }
}
