using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Events
{
    public class OrderCreatedDomainEvent : DomainEventBase
    {
        public OrderCreatedDomainEvent(Guid uniqueId)
        {
            UniqueId = uniqueId;
        }

        public Guid UniqueId { get; }
    }
}
