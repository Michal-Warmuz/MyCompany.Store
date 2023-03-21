using Microsoft.EntityFrameworkCore;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;

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

        public async Task<IReadOnlyList<Order>> GetAllAsync()
        {
            return await _context.Orders
                        .AsNoTracking()
                        .Include(x => x.OrderLines)
                        .ToListAsync();
        }

        public async Task<Order> GetAsync(OrderId orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(x=>x.Id == orderId)
                .Include(x=>x.OrderLines)
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
