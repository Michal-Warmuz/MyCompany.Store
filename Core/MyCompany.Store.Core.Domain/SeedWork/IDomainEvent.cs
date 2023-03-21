namespace MyCompany.Store.Core.Domain.SeedWork
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
