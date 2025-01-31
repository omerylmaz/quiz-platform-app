using Common.Application.Data;
using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.SubscriptionBenefits;

namespace Subscriptions.Application.SubscriptionBenefits.CreateSubscriptionBenefit;

internal sealed class CreateSubscriptionBenefitCommandHandler(
    ISubscriptionBenefitRepository subscriptionBenefitRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateSubscriptionBenefitCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateSubscriptionBenefitCommand request, CancellationToken cancellationToken)
    {
        var subscriptionBenefit = SubscriptionBenefit.Create(new Benefit(request.Name, request.Value));

        subscriptionBenefitRepository.Add(subscriptionBenefit);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return subscriptionBenefit.Id;
    }
}
