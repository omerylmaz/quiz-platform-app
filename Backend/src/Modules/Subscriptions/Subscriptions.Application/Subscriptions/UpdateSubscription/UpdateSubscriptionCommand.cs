using Common.Application.Messaging;

namespace Subscriptions.Application.Subscriptions.UpdateSubscription;

public sealed record UpdateSubscriptionCommand(Guid Id, string Name, decimal Price, List<Guid> SubscriptionBenefitIds) : ICommand;
