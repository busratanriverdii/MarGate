using MarGate.Core.MessageBus;
using MassTransit;
using Serilog;

namespace MarGate.Order.Application.Messaging.OrderCreated;

public class OrderCreatedMessageHandler(ILogger logger) : MessageBaseConsumer<OrderCreatedMessage>(logger)
{
    private readonly ILogger _logger = logger;

    public override Task ConsumeAsync(ConsumeContext<OrderCreatedMessage> context)
    {
        _logger.Information("created order:" + context.Message.OrderId); 
        return Task.CompletedTask;
    }
}
