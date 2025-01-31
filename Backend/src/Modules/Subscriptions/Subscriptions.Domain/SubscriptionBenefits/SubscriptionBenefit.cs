using Common.Domain;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Domain.SubscriptionBenefits;

public sealed class SubscriptionBenefit : Entity
{
    private SubscriptionBenefit() { }

    public Guid Id { get; private set; }
    public Benefit Benefit { get; private set; }
    public ICollection<Subscription> Subscriptions { get; private set; }

    public static SubscriptionBenefit Create(Benefit benefit)
    {
        var subscriptionBenefit = new SubscriptionBenefit()
        {
            Id = Guid.NewGuid(),
            Benefit = benefit,
        };

        return subscriptionBenefit;
    }
}

public sealed record Benefit(string Name, string Value);
