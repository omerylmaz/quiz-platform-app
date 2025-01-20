namespace Quiz.Domain.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccuredOn { get; }
}
