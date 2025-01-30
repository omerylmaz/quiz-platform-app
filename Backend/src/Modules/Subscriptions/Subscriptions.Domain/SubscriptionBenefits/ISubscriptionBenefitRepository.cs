namespace Subscriptions.Domain.SubscriptionBenefits;

public interface ISubscriptionBenefitRepository
{
    void Add(SubscriptionBenefit subscriptionBenefit);
    void Delete(SubscriptionBenefit subscriptionBenefit);
    Task<IReadOnlyCollection<SubscriptionBenefit>> GetAllBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken);
}
