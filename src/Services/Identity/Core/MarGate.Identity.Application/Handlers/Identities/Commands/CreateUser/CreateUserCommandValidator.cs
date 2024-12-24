using FluentValidation;
using MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;

namespace MarGate.Identity.Application.Handlers.Identities.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a first name.")
            .MinimumLength(3)
            .WithMessage("First name must be at least 3 characters long.");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a last name.")
            .MinimumLength(2)
            .WithMessage("Last name must be at least 2 characters long.");

        RuleFor(u => u.BirthDate)
            .NotEmpty()
            .NotNull()
            .LessThanOrEqualTo(System.DateTime.Now.AddYears(-18))
            .WithMessage("You must be at least 18 years old.");

        RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter your phone number.");

        RuleFor(u => u.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter an email address.");

        RuleFor(u => u.PasswordText)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a password.");
    }
}
