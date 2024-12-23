using MarGate.Core.MessageBus;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace MarGate.Order.Application.Messaging.OrderCreated
{
    public class OrderCreatedMessageHandler : MessageBaseConsumer<OrderCreatedMessage>
    {
        private readonly ILogger _logger;

        public OrderCreatedMessageHandler(ILogger logger) : base(logger)
        {
            _logger = logger;
        }

        public override Task ConsumeAsync(ConsumeContext<OrderCreatedMessage> context)
        {
            _logger.LogInformation("created order:" + context.Message.OrderId);
            return Task.CompletedTask;
        }
    }
}
