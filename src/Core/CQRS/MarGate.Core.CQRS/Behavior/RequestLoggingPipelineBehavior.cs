using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MarGate.Core.CQRS.Behavior
{
    public class RequestLoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public RequestLoggingPipelineBehavior(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request {typeof(TRequest).Name} : {JsonSerializer.Serialize(request)}");

            var response = await next();

            _logger.LogInformation($"Response {typeof(TResponse).Name} : {JsonSerializer.Serialize(response)}");

            return response;
        }
    }
}
