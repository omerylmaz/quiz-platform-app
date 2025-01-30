using Common.Domain;

namespace Subscriptions.Domain.SubscriptionBenefits;

public sealed class SubscriptionBenefit : Entity
{
    private SubscriptionBenefit() { }

    public Guid Id { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public Benefit Benefit { get; private set; }

    public static SubscriptionBenefit Create(Guid subscriptionId, Benefit benefit)
    {
        var subscriptionBenefit = new SubscriptionBenefit()
        {
            Id = Guid.NewGuid(),
            Benefit = benefit,
            SubscriptionId = subscriptionId
        };

        return subscriptionBenefit;
    }
}

public sealed record Benefit(string Name, string Value);
