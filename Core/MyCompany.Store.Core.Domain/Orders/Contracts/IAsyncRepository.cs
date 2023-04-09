namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IAsyncRepository<TEntity, TEntityId>
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntityId entityId);
        Task UpdateAsync(TEntity entity);
        Task<TEntity?> GetAsync(TEntityId entityId);
    }
}
