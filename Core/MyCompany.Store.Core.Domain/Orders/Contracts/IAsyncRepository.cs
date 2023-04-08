namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IAsyncRepository<TEntity, TEntityId>
    {
        Task AddAsync(TEntity orderLine);
        Task RemoveAsync(TEntityId orderId);
    }
}
