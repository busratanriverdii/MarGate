using MassTransit;

namespace MarGate.Core.MessageBus.Publisher
{
    internal class MessagePublisher : IMessagePublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessagePublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : class, IMessage
        {
            return _publishEndpoint.Publish(message, cancellationToken);
        }
    }
}