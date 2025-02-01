using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.CustomerSubscriptions;
using Subscriptions.Infrustructure.Database;

namespace Subscriptions.Infrustructure.CustomerSubscriptions;

internal sealed class CustomerSubscriptionRepository(SubscriptionsDbContext dbContext) : ICustomerSubscriptionRepository
{
    public void Add(CustomerSubscription customerSubscription)
    {
        dbContext.CustomerSubscriptions.Add(customerSubscription);
    }

    public void Delete(CustomerSubscription customerSubscription)
    {
        dbContext.CustomerSubscriptions.Remove(customerSubscription);
    }

    public async Task<CustomerSubscription?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.CustomerSubscriptions
            .FirstOrDefaultAsync(us => us.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<CustomerSubscription>> GetWhereAsync(
        Expression<Func<CustomerSubscription, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.CustomerSubscriptions
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }
}
