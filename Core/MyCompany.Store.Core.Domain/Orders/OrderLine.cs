using MyCompany.Store.Core.Domain.SeedWork;
using MyCompany.Store.Core.Domain.Orders.Events;

namespace MyCompany.Store.Core.Domain.Orders
{
    public class OrderLine : Entity<OrderLineId>
    {

        private Amount _price;

        private Product _product;

        private OrderId _orderId;

        public Order Order { get; private set; }

        private OrderLine() { }

        private OrderLine(Amount price, Product product) 
        {
            _price = price;
            _product = product;

            UniqueId = Guid.NewGuid();

            AddDomainEvent(new OrderLineCreatedDomainEvent(UniqueId));
        }

        public static OrderLine CreateNew(Amount price, Product product)
        {
            return new OrderLine(price, product);
        }

        public decimal GetPriceValue() => _price.Value;

        public string GetProductName() => _product.Name;
    }
}
