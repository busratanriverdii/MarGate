using MediatR;

namespace MarGate.Core.CQRS.Command;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult> where TResult : class
{
}
