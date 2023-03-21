using Microsoft.EntityFrameworkCore;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Infrastructure.Database.Configurations;

namespace MyCompany.Store.Infrastructure.Database
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
        }
    }
}
