using Common.Application.Messaging;

namespace Subscriptions.Application.Subscriptions.CreateSubscription;

public sealed record CreateSubscriptionCommand(string Name, decimal Price) : ICommand<Guid>;
