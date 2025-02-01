using Common.Domain;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Domain.CustomerSubscriptions;

public sealed class CustomerSubscription : Entity
{
    private CustomerSubscription() { }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }
    public Customer Customer { get; private set; }
    public Subscription Subscription { get; private set; }

    public static CustomerSubscription Create(Guid customerId, Guid subscriptionId, int subscriptionDays)
    {
        var customerSubscription = new CustomerSubscription()
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            SubscriptionId = subscriptionId,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(subscriptionDays),
            IsActive = true  // For now
        };

        //Event: Subscription Created Domain Event

        return customerSubscription;
    }

    public void RenewSubscription(int subscriptionDays)
    {
        EndDate = DateTime.UtcNow.AddDays(subscriptionDays);

        //Event: Subscription Renewed Domain Event
    }

    public void CancelSubscription()
    {
        IsActive = false;
    }
}
