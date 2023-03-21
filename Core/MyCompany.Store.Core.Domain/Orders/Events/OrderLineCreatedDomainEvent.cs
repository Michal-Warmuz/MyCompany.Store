using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Events
{
    public class OrderLineCreatedDomainEvent : DomainEventBase
    {
        public OrderLineCreatedDomainEvent(Guid uniqueId)
        {
            UniqueId = uniqueId;
        }

        public Guid UniqueId { get; }
    }
}
