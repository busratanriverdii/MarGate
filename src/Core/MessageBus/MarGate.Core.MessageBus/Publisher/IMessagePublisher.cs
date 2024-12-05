namespace MarGate.Core.MessageBus.Publisher;

public interface IMessagePublisher
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : class, IMessage;
}
