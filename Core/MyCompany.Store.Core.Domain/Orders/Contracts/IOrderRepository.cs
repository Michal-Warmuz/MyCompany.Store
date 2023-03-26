using System.Linq.Expressions;

namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order, OrderId>
    {
        void Update(Order order);
        Task<TType> GetAsync<TType>(OrderId orderId, Expression<Func<Order, TType>> select) where TType : class;
        Task<IEnumerable<TType>> GetAllAsync<TType>(int page, int perPage, DateOnly? createdDate, OrderStatus? status, Func<Order, TType> select) where TType : class;
        Task<int> GetRecordsCountAsync();
    }
}
