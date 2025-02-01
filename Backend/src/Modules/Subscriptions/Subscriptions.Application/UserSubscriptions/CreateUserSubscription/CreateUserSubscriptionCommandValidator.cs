using FluentValidation;

namespace Subscriptions.Application.UserSubscriptions.CreateUserSubscription;

internal sealed class CreateUserSubscriptionCommandValidator : AbstractValidator<CreateUserSubscriptionCommand>
{
    public CreateUserSubscriptionCommandValidator()
    {
        RuleFor(s => s.UserId).NotEmpty();
        RuleFor(s => s.SubscriptionId).NotEmpty();
        RuleFor(s => s.SubscriptionDays).GreaterThan(0);
    }
}
