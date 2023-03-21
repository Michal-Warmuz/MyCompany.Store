using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Events
{
    internal class OrderEditedDomainEvent : DomainEventBase
    {
        public OrderEditedDomainEvent(Client client, OrderStatus status, Information additionalInfo)
        {
            Client = client;
            Status = status;
            AdditionalInfo = additionalInfo;
        }

        public Client Client { get; }
        public OrderStatus Status { get; }
        public Information AdditionalInfo { get; }
    }
}
