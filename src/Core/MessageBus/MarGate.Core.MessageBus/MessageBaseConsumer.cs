using MassTransit;
using Microsoft.Extensions.Logging;

namespace MarGate.Core.MessageBus;

public abstract class MessageBaseConsumer<TMessage>(ILogger logger) : IMessageConsumer<TMessage> where TMessage : class, IMessage
{
    public Task Consume(ConsumeContext<TMessage> context)
    {
        try
        {
            return ConsumeAsync(context);
        }
        catch (Exception)
        {
            logger.LogError($"Message : {nameof(context.Message)} is failed.");
            throw;
        }
    }

    public abstract Task ConsumeAsync(ConsumeContext<TMessage> context);
}