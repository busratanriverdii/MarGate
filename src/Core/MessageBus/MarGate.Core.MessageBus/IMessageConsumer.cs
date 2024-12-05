using MassTransit;

namespace MarGate.Core.MessageBus;

public interface IMessageConsumer<TMessage> : IMessageConsumer, IConsumer<TMessage> where TMessage : class, IMessage
{

}

public interface IMessageConsumer
{

}