using Common.Application.Messaging;

namespace Subscriptions.Application.Subscriptions.GetSubscriptions;

public sealed record GetSubscriptionsQuery() : IQuery<IReadOnlyCollection<SubscriptionResponse>>;
