using Common.Domain;
using Subscriptions.Domain.SubscriptionBenefits;

namespace Subscriptions.Domain.Subscriptions;

public sealed class Subscription : Entity
{
    private Subscription() { }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public ICollection<SubscriptionBenefit> SubscriptionBenefits { get; private set; }

    public static Subscription Create(string name, decimal price)
    {
        var subscription = new Subscription()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price
        };

        return subscription;
    }

    public void AddBenefit(SubscriptionBenefit subscriptionBenefit)
    {
        SubscriptionBenefits.Add(subscriptionBenefit);
    }

    public void RemoveBenefit(SubscriptionBenefit subscriptionBenefit)
    {
        SubscriptionBenefits.Remove(subscriptionBenefit);
    }
}
