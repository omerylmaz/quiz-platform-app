using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.SubscriptionBenefits;
using Subscriptions.Infrustructure.Database;

namespace Subscriptions.Infrustructure.SubscriptionBenefits;

internal sealed class SubscriptionBenefitRepository(SubscriptionsDbContext dbContext) : ISubscriptionBenefitRepository
{
    public void Add(SubscriptionBenefit subscriptionBenefit)
    {
        dbContext.SubscriptionBenefits.Add(subscriptionBenefit);
    }

    public void Delete(SubscriptionBenefit subscriptionBenefit)
    {
        dbContext.SubscriptionBenefits.Remove(subscriptionBenefit);
    }

    public async Task<IReadOnlyCollection<SubscriptionBenefit>> GetAllBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
    {
        return await dbContext.SubscriptionBenefits
            .AsNoTracking()
            .Where(sb => sb.Subscriptions.Any(s => s.Id == subscriptionId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<SubscriptionBenefit>> GetAllWhereAsync(Expression<Func<SubscriptionBenefit, bool>> expression, CancellationToken cancellationToken)
    {
        return await dbContext.SubscriptionBenefits
            .AsNoTracking()
            .Where(expression)
            .ToListAsync(cancellationToken);
    }
}
