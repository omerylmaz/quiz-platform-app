namespace Common.Domain;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccuredOn = DateTime.UtcNow;
    }

    protected DomainEvent(Guid id, DateTime occuredOn)
    {
        Id = id;
        OccuredOn = occuredOn;
    }

    public Guid Id { get; init; }

    public DateTime OccuredOn { get; init; }
}
