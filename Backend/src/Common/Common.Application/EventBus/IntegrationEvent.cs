namespace Common.Application.EventBus;

public abstract class IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; init; }

    public DateTime OccuredOn { get; init; }

    protected IntegrationEvent(Guid id, DateTime occuredOn)
    {
        Id = id;
        OccuredOn = occuredOn;
    }
}
