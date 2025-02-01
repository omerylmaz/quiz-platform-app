using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Application.Abstractions.Data;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.CustomerSubscriptions;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Application.CustomerSubscriptions.CreateCustomerSubscription;

internal sealed class CreateCustomerSubscriptionCommandHandler(
    ICustomerSubscriptionRepository customerSubscriptionRepository,
    ISubscriptionRepository subscriptionRepository,
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerSubscriptionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerSubscriptionCommand request, CancellationToken cancellationToken)
    {
        Subscription? subscription = await subscriptionRepository.GetAsync(request.SubscriptionId, cancellationToken);

        if (subscription is null)
            return Result.Failure<Guid>(SubscriptionErrors.NotFound(request.SubscriptionId));

        Customer? customer = await customerRepository.GetAsync(request.CustomerId, cancellationToken);

        if (customer is null)
            return Result.Failure<Guid>(CustomerErrors.NotFound(request.CustomerId));

        var customerSubscription = CustomerSubscription.Create(request.CustomerId, request.SubscriptionId, request.SubscriptionDays);

        customerSubscriptionRepository.Add(customerSubscription);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return customerSubscription.Id;
    }
}
