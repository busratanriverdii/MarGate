﻿using FluentValidation;
using MediatR;

namespace MarGate.Core.CQRS.Behavior;

public class RequestValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var errors = _validators
            .Select(x => x.Validate(request))
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .ToList();


        return errors.Any()
            ? throw new Common.Exception.ValidationException(
                string.Join(",", errors.Select(x => x.ErrorCode).Distinct()),
                string.Join(",", errors.Select(x => x.ErrorMessage).Distinct()))
            : next();
    }
}
