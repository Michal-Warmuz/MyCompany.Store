namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IAsyncRepository<TEntity, TEntityId>
    {
        Task AddAsync(TEntity orderLine);
        Task<TEntity> GetAsync(TEntityId orderLineId);
        Task RemoveAsync(TEntityId orderId);
        Task<int> CommitAsync();
    }
}
