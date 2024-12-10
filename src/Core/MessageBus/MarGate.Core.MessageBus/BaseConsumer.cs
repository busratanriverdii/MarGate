using MassTransit;
using Microsoft.Extensions.Logging;

namespace MarGate.Core.MessageBus;

public abstract class BaseConsumer<TMessage>(ILogger<BaseConsumer<TMessage>> logger) : IMessageConsumer<TMessage> where TMessage : class, IMessage
{
    private readonly ILogger<BaseConsumer<TMessage>> _logger = logger;

    // Template Method
    public async Task Consume(ConsumeContext<TMessage> context)
    {
        try
        {
            await ProcessMessage(context.Message);

            _logger.LogInformation($"Message processed successfully: {context.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing message: {ex.Message}");
            HandleError(ex, context.Message);
        }
    }

    protected abstract Task ProcessMessage(TMessage message);

    private void HandleError(Exception ex, TMessage message)
    {
        _logger.LogError($"Handling error for message: {message}. Exception: {ex.Message}");
    }
}
