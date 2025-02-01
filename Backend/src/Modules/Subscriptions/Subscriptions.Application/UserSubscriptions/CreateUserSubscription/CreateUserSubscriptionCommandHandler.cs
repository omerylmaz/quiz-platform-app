using Common.Application.Data;
using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Domain.UserSubscriptions;

namespace Subscriptions.Application.UserSubscriptions.CreateUserSubscription;

internal sealed class CreateUserSubscriptionCommandHandler(
    IUserSubscriptionRepository userSubscriptionRepository,
    ISubscriptionRepository subscriptionRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateUserSubscriptionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateUserSubscriptionCommand request, CancellationToken cancellationToken)
    {
        Subscription? subscription = await subscriptionRepository.GetAsync(request.SubscriptionId, cancellationToken);

        if (subscription is null)
            return Result.Failure<Guid>(SubscriptionErrors.NotFound(request.SubscriptionId));

        // userid check

        var userSubscription = UserSubscription.Create(request.UserId, request.SubscriptionId, request.SubscriptionDays);

        userSubscriptionRepository.Add(userSubscription);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return userSubscription.Id;
    }
}
