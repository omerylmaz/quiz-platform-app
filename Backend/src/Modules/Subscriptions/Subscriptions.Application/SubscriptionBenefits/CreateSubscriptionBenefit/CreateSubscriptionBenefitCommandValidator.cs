using FluentValidation;

namespace Subscriptions.Application.SubscriptionBenefits.CreateSubscriptionBenefit;

internal sealed class CreateSubscriptionBenefitCommandValidator : AbstractValidator<CreateSubscriptionBenefitCommand>
{
    public CreateSubscriptionBenefitCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Value)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(255);
    }
}
