using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Store.Core.Domain.Orders;

namespace MyCompany.Store.Infrastructure.Database.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(
                    v => v.Value,
                    v => new OrderId(v))
                .ValueGeneratedOnAdd();

            builder.Property(c => c.UniqueId);

            builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");

            builder.OwnsOne<OrderStatus>("_status", b =>
            {
                b.Property(p => p.Value).HasColumnName("Status");
            });

            builder.OwnsOne<Client>("_client", b =>
            {
                b.Property(p => p.Name).HasColumnName("ClientName");
            });

            builder.OwnsOne<Information>("_additionalInfo", b =>
            {
                b.Property(p => p.Value).HasColumnName("AdditionalInfo");
            });


            builder.HasMany(x => x.OrderLines).WithOne(x=>x.Order).HasForeignKey("_orderId");
        }
    }
}
