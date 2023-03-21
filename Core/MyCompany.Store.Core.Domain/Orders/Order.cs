using MyCompany.Store.Core.Domain.Orders.Events;
using MyCompany.Store.Core.Domain.Orders.Rules;
using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders
{

    public class Order : Entity<OrderId>, IAggregateRoot
    {

        private DateTime _createDate;

        private Information _additionalInfo;

        private Client _client;

        private List<OrderLine> _orderLines;

        private OrderStatus _status;

        public IReadOnlyList<OrderLine> OrderLines => _orderLines.AsReadOnly();

        private Order() 
        {
            _orderLines = new List<OrderLine>();
        }

        private Order(Information additionalInfo, Client client)
        {
            UniqueId = Guid.NewGuid();

            _createDate = DateTime.Now;
            _additionalInfo = additionalInfo;
            _client = client;
            _orderLines = new List<OrderLine>();
            _status = OrderStatus.New;

            AddDomainEvent(new OrderCreatedDomainEvent(UniqueId));
        }

        public static Order CreateNew(Information additionalInfo, Client client)
        {
            return new Order(additionalInfo, client);
        }

        public void Edit(Information additionalInfo, Client client, OrderStatus status)
        {
            CheckRule(new OrderCannotBeEditedWhenStatusIsNewRule(_status));

            _additionalInfo = additionalInfo;
            _client = client;
            _status = status;

            AddDomainEvent(new OrderEditedDomainEvent(client, status, additionalInfo));
        }


        public void Remove()
        {
            CheckRule(new OrderCannotBeRemoveedOnlyWhenStatusNotEqualNewRule(_status));

            AddDomainEvent(new OrderRemovedDomainEvent(UniqueId));
        }


        public void AddOrderLine(Amount amount, Product product)
        {
            _orderLines.Add(OrderLine.CreateNew(amount, product));
        }

        public decimal GetOrderPirce() => _orderLines.Sum(x => x.GetPriceValue());

        public string GetClientName() => _client.Name;

        public string GetAdditionalInfo() => _additionalInfo.Value;

        public string GetOrderStatus() => _status.Value;

        public DateTime GetCreatedDate() => _createDate;

        public void Cancel()
        {
            _status = OrderStatus.Cancel;
        }

        public void Delivery()
        {
            _status = OrderStatus.Delivery;
        }

        public void Confirm()
        {
            _status = OrderStatus.Confirm;
        }
    }
}
