using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Events
{
    internal class OrderLineRemovedDomainEvent : DomainEventBase
    {
        public OrderLineRemovedDomainEvent(Guid uniqueId)
        {
            UniqueId = uniqueId;
        }

        public Guid UniqueId { get; }
    }
}
