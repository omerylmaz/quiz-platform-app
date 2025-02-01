using FluentValidation;

namespace Subscriptions.Application.CustomerSubscriptions.CreateCustomerSubscription;

internal sealed class CreateCustomerSubscriptionCommandValidator : AbstractValidator<CreateCustomerSubscriptionCommand>
{
    public CreateCustomerSubscriptionCommandValidator()
    {
        RuleFor(s => s.CustomerId).NotEmpty();
        RuleFor(s => s.SubscriptionId).NotEmpty();
        RuleFor(s => s.SubscriptionDays).GreaterThan(0);
    }
}
