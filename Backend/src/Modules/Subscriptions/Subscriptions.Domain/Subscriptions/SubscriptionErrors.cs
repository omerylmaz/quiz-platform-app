using Common.Domain;

namespace Subscriptions.Domain.Subscriptions;

public static class SubscriptionErrors
{
    public static Error NotFound(Guid subscriptionId) =>
    Error.NotFound("Subscriptions.NotFound", $"The subscription with the identifier {subscriptionId} not found");
}
