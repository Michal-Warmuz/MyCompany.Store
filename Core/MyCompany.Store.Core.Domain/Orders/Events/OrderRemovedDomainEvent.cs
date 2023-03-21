using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Events
{
    public class OrderRemovedDomainEvent : DomainEventBase
    {
        public OrderRemovedDomainEvent(Guid uniqueId)
        {
            UniqueId = uniqueId;
        }

        public Guid UniqueId { get; }
    }
}
