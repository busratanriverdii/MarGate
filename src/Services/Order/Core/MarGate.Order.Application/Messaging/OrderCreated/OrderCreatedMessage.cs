using MarGate.Core.MessageBus;

namespace MarGate.Order.Application.Messaging.OrderCreated;

public class OrderCreatedMessage : IMessage
{
    public long OrderId { get; set; }
}
