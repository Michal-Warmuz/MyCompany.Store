using Microsoft.EntityFrameworkCore;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using System.Linq.Expressions;

namespace MyCompany.Store.Infrastructure.Database.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.AddAsync(order);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Order>> GetAllAsync(int page, int perPage)
        {
            return await _context.Orders
                        .Skip((page - 1) * perPage)
                        .Take(perPage)
                        .AsNoTracking()
                        .Include(x => x.OrderLines)
                        .ToListAsync();
        }

        public async Task<IReadOnlyList<TType>> GetAllAsync<TType>(int page, int perPage, DateTime? createdDate, OrderStatus? status,  Expression<Func<Order, TType>> select) where TType : class
        {

            var query = _context.Orders
                        .Skip((page - 1) * perPage)
                        .Take(perPage)
                        .AsNoTracking()
                        .Include(x => x.OrderLines)
                        .AsQueryable();

            if(createdDate.HasValue)
            {
                query = query.Where(x => x.GetCreatedDate() == createdDate);
            }

            if(status != null)
            {
                query = query.Where(x => x.GetOrderStatus() == status.Value);
            }


            return await query.Select(select).ToListAsync();
        }

        public async Task<Order> GetAsync(OrderId orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(x=>x.Id == orderId)
                .Include(x=>x.OrderLines)
                .FirstOrDefaultAsync();
        }

        public async Task<TType> GetAsync<TType>(OrderId orderId, Expression<Func<Order, TType>> select) where TType : class
        {
            return await _context.Orders
                        .AsNoTracking()
                        .Where(x => x.Id == orderId)
                        .Include(x => x.OrderLines)
                        .Select(select)
                        .FirstOrDefaultAsync();
        }

        public void Remove(Order order)
        {
            _context.Remove(order);
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
