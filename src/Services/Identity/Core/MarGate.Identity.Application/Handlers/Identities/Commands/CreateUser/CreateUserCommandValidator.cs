using FluentValidation;
using MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;
using System.Text.RegularExpressions;

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
            .WithMessage("Please enter your phone number.")
            .Must(CheckPhoneNumberValidation)
            .WithMessage("Please enter a valid phone number.");

        RuleFor(u => u.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter an email address.")
            .Must(CheckEmailValidation)
            .WithMessage("Please enter a valid email address.");

        RuleFor(u => u.PasswordText)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a password.")
            .Must(CheckPasswordValidation)
            .WithMessage("Please enter a valid password.");
    }

    public static bool CheckEmailValidation(string email)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.Compiled);
        return regex.IsMatch(email);
    }

    // Validates Turkish phone numbers starting with 5 and followed by 9 digits
    public static bool CheckPhoneNumberValidation(string phoneNumber)
    {
        var regex = new Regex(@"^[5]{1}[0-9]{9}$", RegexOptions.Compiled);
        return regex.IsMatch(phoneNumber);
    }

    // Validates password with at least one uppercase, one lowercase, one special character, and minimum length of 6
    public static bool CheckPasswordValidation(string password)
    {
        var regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[#?!@$%^&*-]).{6,}$", RegexOptions.Compiled);
        return regex.IsMatch(password);
    }

}
