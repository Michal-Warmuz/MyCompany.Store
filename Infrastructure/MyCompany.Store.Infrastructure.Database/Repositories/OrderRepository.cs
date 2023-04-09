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

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
        }

        public async Task<Order?> GetAsync(OrderId entityId)
        {
            return await _context.Orders.SingleOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task RemoveAsync(OrderId entityId)
        {
            await _context.Orders.Where(x => x.Id == entityId).ExecuteDeleteAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);

            await Task.CompletedTask;
        }
    }
}
