using MarGate.Core.MessageBus;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace MarGate.Order.Application.Messaging.OrderCreated;

public class OrderCreatedMessageHandler(ILogger logger) : MessageBaseConsumer<OrderCreatedMessage>(logger)
{
    private readonly ILogger _logger = logger;

    public override Task ConsumeAsync(ConsumeContext<OrderCreatedMessage> context)
    {
        _logger.LogInformation("created order:" + context.Message.OrderId); //infoyu da base e koyalım
        return Task.CompletedTask;
    }
}
