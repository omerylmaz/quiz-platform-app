namespace Subscriptions.Application.Subscriptions.GetSubscriptions;

public sealed record SubscriptionResponse(Guid Id, string Name, decimal Price, List<SubscriptionBenefitResponse> Benefits);

public sealed record SubscriptionBenefitResponse(Guid Id, string Name, string Value);
