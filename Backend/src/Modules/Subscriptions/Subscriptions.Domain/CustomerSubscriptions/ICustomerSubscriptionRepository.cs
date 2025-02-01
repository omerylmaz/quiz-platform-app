using System.Linq.Expressions;

namespace Subscriptions.Domain.CustomerSubscriptions;

public interface ICustomerSubscriptionRepository
{
    void Add(CustomerSubscription customerSubscription);
    void Delete(CustomerSubscription customerSubscription);
    Task<CustomerSubscription?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<CustomerSubscription>> GetWhereAsync(Expression<Func<CustomerSubscription, bool>> predicate, CancellationToken cancellationToken);
}
