using FluentValidation;

namespace MarGate.Core.CQRS.Validator;

public interface ICQRSValidator : IValidator
{
}

public interface ICQRSValidator<in T> : ICQRSValidator, IValidator<T>
{
}
