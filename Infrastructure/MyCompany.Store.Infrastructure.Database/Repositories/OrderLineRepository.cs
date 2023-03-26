using Microsoft.EntityFrameworkCore;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;

namespace MyCompany.Store.Infrastructure.Database.Repositories
{
    internal class OrderLineRepository : IOrderLineRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderLineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderLine orderLine)
        {
            await _context.OrderLines.AddAsync(orderLine);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<OrderLine> GetAsync(OrderLineId orderLineId)
        {
            return await _context.OrderLines.SingleOrDefaultAsync(x => x.Id == orderLineId);
        }

        public async Task RemoveAsync(OrderLineId orderLineId)
        {
            await _context.OrderLines.Where(x=>x.Id == orderLineId).ExecuteDeleteAsync();
        }
    }
}
