using FluentValidation;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommandRequest> 
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.PaymentMethodType)
            .IsInEnum()
            .WithMessage("Please provide a valid payment method type.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Please provide a valid payment status.");

        RuleFor(x => x.TransactionId)
            .NotEmpty()
            .WithMessage("Transaction ID is required.");
    }
}
