using Common.Domain;
using Subscriptions.Domain.SubscriptionBenefits;

namespace Subscriptions.Domain.Subscriptions;

public sealed class Subscription : Entity
{
    private Subscription()
    {
        SubscriptionBenefits = [];
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ICollection<SubscriptionBenefit> SubscriptionBenefits { get; private set; }

    public static Subscription Create(string name, decimal price)
    {
        return new Subscription
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price
        };
    }

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public void AddBenefit(SubscriptionBenefit subscriptionBenefit)
    {
        if (subscriptionBenefit is not null && !SubscriptionBenefits.Any(b => b.Id == subscriptionBenefit.Id))
        {
            SubscriptionBenefits.Add(subscriptionBenefit);
        }
    }

    public void RemoveBenefit(SubscriptionBenefit subscriptionBenefit)
    {
        if (subscriptionBenefit is not null && SubscriptionBenefits.Contains(subscriptionBenefit))
        {
            SubscriptionBenefits.Remove(subscriptionBenefit);
        }
    }

    public void ClearBenefits()
    {
        SubscriptionBenefits.Clear();
    }
}
