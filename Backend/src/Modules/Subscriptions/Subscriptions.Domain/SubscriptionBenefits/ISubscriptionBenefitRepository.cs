using System.Linq.Expressions;

namespace Subscriptions.Domain.SubscriptionBenefits;

public interface ISubscriptionBenefitRepository
{
    void Add(SubscriptionBenefit subscriptionBenefit);
    void Delete(SubscriptionBenefit subscriptionBenefit);
    Task<IReadOnlyCollection<SubscriptionBenefit>> GetAllBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<SubscriptionBenefit>> GetAllWhereAsync(Expression<Func<SubscriptionBenefit, bool>> expression, CancellationToken cancellationToken);
}
