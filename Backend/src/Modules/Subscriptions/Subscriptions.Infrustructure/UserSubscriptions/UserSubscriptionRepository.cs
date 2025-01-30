using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.UserSubscriptions;
using Subscriptions.Infrustructure.Database;

namespace Subscriptions.Infrustructure.UserSubscriptions;

internal sealed class UserSubscriptionRepository(SubscriptionsDbContext dbContext) : IUserSubscriptionRepository
{
    public void Add(UserSubscription userSubscription)
    {
        dbContext.UserSubscriptions.Add(userSubscription);
    }

    public void Delete(UserSubscription userSubscription)
    {
        dbContext.UserSubscriptions.Remove(userSubscription);
    }

    public async Task<UserSubscription?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.UserSubscriptions
            .FirstOrDefaultAsync(us => us.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<UserSubscription>> GetWhereAsync(
        Expression<Func<UserSubscription, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.UserSubscriptions
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }
}
