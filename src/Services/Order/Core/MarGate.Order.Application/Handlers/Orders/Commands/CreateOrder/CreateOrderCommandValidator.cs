using FluentValidation;
using MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

namespace MarGate.Order.Application.Handlers.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.Description)
        .NotEmpty()
        .NotNull()
        .WithMessage("Please enter a description.")
        .Length(10, 150) 
        .WithMessage("Description must be between 10 and 150 characters.");

        RuleFor(o => o.Address)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter the order address.")
            .MaximumLength(250)
            .WithMessage("The order address must not exceed 250 characters.");
    }
}
