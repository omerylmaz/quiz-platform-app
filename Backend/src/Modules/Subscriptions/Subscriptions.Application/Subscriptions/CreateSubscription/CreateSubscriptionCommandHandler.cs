using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Application.Abstractions.Data;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Application.Subscriptions.CreateSubscription;

internal sealed class CreateSubscriptionCommandHandler(
    ISubscriptionRepository subscriptionRepository,
    //ISubscriptionBenefitRepository subscriptionBenefitRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateSubscriptionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = Subscription.Create(request.Name, request.Price);

        subscriptionRepository.Add(subscription);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return subscription.Id;
    }
}
