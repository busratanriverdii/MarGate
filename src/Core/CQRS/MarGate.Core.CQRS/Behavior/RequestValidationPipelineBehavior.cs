using FluentValidation;
using MediatR;

namespace MarGate.Core.CQRS.Behavior
{
    public class RequestValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var erros = _validators
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .ToList();


            return erros.Any()
                ? throw new Common.Exception.ValidationException(
                    string.Join(",", erros.Select(x => x.ErrorCode).Distinct()),
                    string.Join(",", erros.Select(x => x.ErrorMessage).Distinct()))
                : next();
        }
    }
}
