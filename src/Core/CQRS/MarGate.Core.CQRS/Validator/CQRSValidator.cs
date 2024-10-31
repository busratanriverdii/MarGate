using FluentValidation;

namespace MarGate.Core.CQRS.Validator
{
    public class CQRSValidator<T> : AbstractValidator<T>, ICQRSValidator<T>
    {
    }
}
