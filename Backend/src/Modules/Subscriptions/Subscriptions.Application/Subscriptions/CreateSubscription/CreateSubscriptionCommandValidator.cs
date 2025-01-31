using FluentValidation;

namespace Subscriptions.Application.Subscriptions.CreateSubscription;

internal sealed class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(s => s.Name).NotEmpty().MinimumLength(3);

        RuleFor(s => s.Price).GreaterThanOrEqualTo(0);
    }
}
