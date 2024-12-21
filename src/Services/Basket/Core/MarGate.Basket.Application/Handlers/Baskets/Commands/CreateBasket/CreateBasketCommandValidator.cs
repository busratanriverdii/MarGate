using FluentValidation;
using MarGate.Basket.Application.Handlers.Basket.Commands.CreateBasket;

namespace MarGate.Basket.Application.Handlers.Baskets.Commands.CreateBasket;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommandRequest>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(b => b.UserId)
       .NotEmpty()
       .WithMessage("Please enter a User ID.");
    }
}
