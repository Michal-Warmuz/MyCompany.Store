namespace MyCompany.Store.Core.Domain.Orders.Contracts.Base
{
    public interface IAsyncRepository<TEntity, TEntityId>
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntityId entityId);
        Task UpdateAsync(TEntity entity);
        Task<TEntity?> GetAsync(TEntityId entityId);
    }
}
