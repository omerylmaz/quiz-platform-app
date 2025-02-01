using FluentValidation;

namespace Subscriptions.Application.Payments.CreatePayment;

internal sealed class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.Amount).GreaterThan(0);
        RuleFor(p => p.TransactionId).NotEmpty();
    }
}
