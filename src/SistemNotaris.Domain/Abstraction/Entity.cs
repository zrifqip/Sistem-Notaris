namespace SistemNotaris.Domain.Abstraction.Entity;

public abstract class Entity<T>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(T id)
    {
        Id = id;
    }

    public T Id { get; init; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}