using System.Linq.Expressions;

namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        void Remove(Order order);
        void Update(Order order);
        Task<Order> GetAsync(OrderId orderId);
        Task<TType> GetAsync<TType>(OrderId orderId, Expression<Func<Order, TType>> select) where TType : class;
        Task<IReadOnlyList<TType>> GetAllAsync<TType>(int page, int perPage, DateTime? createdDate, OrderStatus? status, Expression<Func<Order, TType>> select) where TType : class;
        Task<int> CommitAsync();
    }
}
