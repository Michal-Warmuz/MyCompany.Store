using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Store.Core.Domain.Orders;

namespace MyCompany.Store.Infrastructure.Database.Configurations
{
    internal class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(
                    v => v.Value,
                    v => new OrderLineId(v))
                .ValueGeneratedOnAdd();

            builder.Property<OrderId>("_orderId").HasColumnName("OrderId")
                    .HasConversion(
                        v => v.Value,
                        v => new OrderId(v));

            builder.Property(c => c.UniqueId);

            builder.OwnsOne<Amount>("_price", b =>
            {
                b.Property(p => p.Value).HasColumnName("Price");
            });

            builder.OwnsOne<Product>("_product", b =>
            {
                b.Property(p => p.Name).HasColumnName("Product");
            });
        }
    }
}
