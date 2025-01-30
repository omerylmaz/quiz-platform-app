using System.Linq.Expressions;

namespace Subscriptions.Domain.UserSubscriptions;

public interface IUserSubscriptionRepository
{
    void Add(UserSubscription userSubscription);
    void Delete(UserSubscription userSubscription);
    Task<UserSubscription?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<UserSubscription>> GetWhereAsync(Expression<Func<UserSubscription, bool>> predicate, CancellationToken cancellationToken);
}
