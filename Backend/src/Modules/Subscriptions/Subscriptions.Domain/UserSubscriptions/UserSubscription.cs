using Common.Domain;

namespace Subscriptions.Domain.UserSubscriptions;

public sealed class UserSubscription : Entity
{
    private UserSubscription() { }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }

    public static UserSubscription Create(Guid userId, Guid subscriptionId, int subscriptionDays)
    {
        var userSubscription = new UserSubscription()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            SubscriptionId = subscriptionId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(subscriptionDays),
            IsActive = true  // For now
        };

        //Event: Subscription Created Domain Event

        return userSubscription;
    }

    public void RenewSubscription(int subscriptionDays)
    {
        EndDate = DateTime.Now.AddDays(subscriptionDays);

        //Event: Subscription Renewed Domain Event
    }

    public void CancelSubscription()
    {
        IsActive = false;
    }
}
