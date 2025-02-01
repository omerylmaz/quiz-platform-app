using Common.Application.Messaging;

namespace Subscriptions.Application.UserSubscriptions.CreateUserSubscription;

public sealed record CreateUserSubscriptionCommand(Guid UserId, Guid SubscriptionId, int SubscriptionDays) : ICommand<Guid>;
