namespace Domain.Shared;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
    public ICollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}