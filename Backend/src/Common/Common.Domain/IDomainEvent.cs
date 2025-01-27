using MediatR;

namespace Common.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccuredOn { get; }
}
