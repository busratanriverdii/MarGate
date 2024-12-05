using MassTransit;

namespace MarGate.Core.MessageBus.Publisher;

internal class MessagePublisher(IPublishEndpoint publishEndpoint) : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : class, IMessage
    {
        return _publishEndpoint.Publish(message, cancellationToken);
    }
}