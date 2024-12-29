using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MarGate.Core.CQRS.Behavior;

public class RequestLoggingPipelineBehavior<TRequest, TResponse>(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Request {typeof(TRequest).Name} : {JsonSerializer.Serialize(request)}");

        var response = await next();

        logger.LogInformation($"Response {typeof(TResponse).Name} : {JsonSerializer.Serialize(response)}");

        return response;
    }
}
