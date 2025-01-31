using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Infrustructure.Database;

namespace Subscriptions.Infrustructure.Subscriptions;

internal sealed class SubscriptionRepository(SubscriptionsDbContext dbContext) : ISubscriptionRepository
{
    public void Add(Subscription subscription)
    {
        dbContext.Subscriptions.Add(subscription);
    }

    public void Delete(Subscription subscription)
    {
        dbContext.Subscriptions.Remove(subscription);
    }

    public async Task<IReadOnlyCollection<Subscription>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Subscriptions.AsNoTracking().Include(s => s.SubscriptionBenefits).ToListAsync(cancellationToken);
    }

    public async Task<Subscription> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
}
