using Common.Application.EventBus;

namespace Subscriptions.IntegrationEvents;

public class UserRegisteredIntegrationEvent : IntegrationEvent
{
    public Guid UserId { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public UserRegisteredIntegrationEvent(
        Guid id,
        DateTime occuredOn,
        Guid userId,
        string email,
        string firstName,
        string lastName)
        : base(id, occuredOn)
    {
        Id = id;
        OccuredOn = occuredOn;
        UserId = userId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}
