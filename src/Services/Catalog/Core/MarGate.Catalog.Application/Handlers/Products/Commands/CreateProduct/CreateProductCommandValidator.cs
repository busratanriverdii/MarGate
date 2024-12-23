using FluentValidation;
using MarGate.Catalog.Application.Handlers.Products.Commands.CreateCatalog;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a product name.")
            .Length(3, 75)
            .WithMessage("Product name must be between 3 and 75 characters.");

        RuleFor(p => p.UnitsInStock)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter the product's stock quantity.")
            .Must(stock => stock >= 0)
            .WithMessage("Stock quantity must be greater than or equal to 0.");

        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter the product's price.")
            .Must(price => price >= 0)
            .WithMessage("Price must be greater than or equal to 0.");

        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a Category ID.");
    }
}
