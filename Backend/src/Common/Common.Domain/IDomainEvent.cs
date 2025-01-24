namespace Common.Domain;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccuredOn { get; }
}
