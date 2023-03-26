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

        private OrderLine(OrderId orderId, Amount price, Product product) 
        {
            _price = price;
            _product = product;
            _orderId = orderId;

            UniqueId = Guid.NewGuid();

            AddDomainEvent(new OrderLineCreatedDomainEvent(UniqueId));
        }

        public static OrderLine CreateNew(OrderId orderId, Amount price, Product product)
        {
            return new OrderLine(orderId, price, product);
        }

        public decimal GetPriceValue() => _price.Value;

        public string GetProductName() => _product.Name;

        internal void Remove()
        {
            AddDomainEvent(new OrderLineRemovedDomainEvent(UniqueId));
        }
    }
}
