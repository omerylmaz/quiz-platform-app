namespace Subscriptions.Domain.Subscriptions;

public interface ISubscriptionRepository
{
    void Add(Subscription subscription);
    void Delete(Subscription subscription);
    Task<Subscription> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Subscription>> GetAllAsync(CancellationToken cancellationToken);
}
