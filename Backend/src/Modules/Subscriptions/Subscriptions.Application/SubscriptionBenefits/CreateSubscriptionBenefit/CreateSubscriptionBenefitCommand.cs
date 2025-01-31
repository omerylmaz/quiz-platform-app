using Common.Application.Messaging;

namespace Subscriptions.Application.SubscriptionBenefits.CreateSubscriptionBenefit;

public record CreateSubscriptionBenefitCommand(string Name, string Value) : ICommand<Guid>;
