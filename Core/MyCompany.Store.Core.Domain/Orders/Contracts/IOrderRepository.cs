namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        void Remove(Order order);
        void Update(Order order);
        Task<Order> GetAsync(OrderId orderId);
        Task<IReadOnlyList<Order>> GetAllAsync();
        Task<int> CommitAsync();
    }
}
