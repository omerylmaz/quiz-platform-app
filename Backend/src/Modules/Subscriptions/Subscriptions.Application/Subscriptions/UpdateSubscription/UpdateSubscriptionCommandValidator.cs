using FluentValidation;

namespace Subscriptions.Application.Subscriptions.UpdateSubscription;

internal sealed class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
{
    public UpdateSubscriptionCommandValidator()
    {
        RuleFor(s => s.Id)
            .NotEmpty();

        RuleFor(s => s.Name)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(s => s.Price)
            .GreaterThanOrEqualTo(0);
    }
}
