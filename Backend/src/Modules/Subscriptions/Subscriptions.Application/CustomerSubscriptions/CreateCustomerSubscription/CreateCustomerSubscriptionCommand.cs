using Common.Application.Messaging;

namespace Subscriptions.Application.CustomerSubscriptions.CreateCustomerSubscription;

public sealed record CreateCustomerSubscriptionCommand(Guid CustomerId, Guid SubscriptionId, int SubscriptionDays) : ICommand<Guid>;
