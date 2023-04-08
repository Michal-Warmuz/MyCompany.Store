using Microsoft.EntityFrameworkCore;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using System.Linq;
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

        public async Task RemoveAsync(OrderId orderId)
        {
            await _context.Orders.Where(x => x.Id == orderId).ExecuteDeleteAsync();
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
