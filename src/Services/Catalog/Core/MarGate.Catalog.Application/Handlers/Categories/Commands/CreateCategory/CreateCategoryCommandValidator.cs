using FluentValidation;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a category name.")
            .Length(3, 75)
            .WithMessage("Please enter a category name between 3 and 75 characters.");

        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a description.")
            .Length(10, 150)
            .WithMessage("Please enter a category description between 10 and 150 characters.");
    }

}
