using Common.Application.Data;
using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.SubscriptionBenefits;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Application.Subscriptions.UpdateSubscription;

internal sealed class UpdateSubscriptionCommandHandler(
    ISubscriptionRepository subscriptionRepository,
    ISubscriptionBenefitRepository subscriptionBenefitRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateSubscriptionCommand>
{
    public async Task<Result> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        Subscription? subscription = await subscriptionRepository.GetAsync(request.Id, cancellationToken);
        if (subscription is null)
            return Result.Failure<Guid>(SubscriptionErrors.NotFound(request.Id));

        subscription.Update(request.Name, request.Price);

        subscription.ClearBenefits();

        if (request.SubscriptionBenefitIds.Any())
        {
            IReadOnlyCollection<SubscriptionBenefit> subscriptionBenefits = await subscriptionBenefitRepository
                .GetAllWhereAsync(sb => request.SubscriptionBenefitIds.Contains(sb.Id), cancellationToken);

            foreach (SubscriptionBenefit subscriptionBenefit in subscriptionBenefits)
            {
                subscription.AddBenefit(subscriptionBenefit);
            }
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
