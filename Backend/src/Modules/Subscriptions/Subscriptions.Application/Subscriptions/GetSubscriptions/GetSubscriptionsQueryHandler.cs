using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Application.Subscriptions.GetSubscriptions;

internal sealed class GetSubscriptionsQueryHandler(
    ISubscriptionRepository subscriptionRepository) : IQueryHandler<GetSubscriptionsQuery, IReadOnlyCollection<SubscriptionResponse>>
{
    public async Task<Result<IReadOnlyCollection<SubscriptionResponse>>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Subscription> subscriptions = await subscriptionRepository.GetAllAsync(cancellationToken);

        return subscriptions.Select(s => new SubscriptionResponse(
            s.Id,
            s.Name,
            s.Price,
            s.SubscriptionBenefits.Select(b => new SubscriptionBenefitResponse(b.Id, b.Benefit.Name, b.Benefit.Value)).ToList()
        )).ToList();
    }
}
