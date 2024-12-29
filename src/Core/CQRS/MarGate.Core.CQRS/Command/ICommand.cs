using MediatR;

namespace MarGate.Core.CQRS.Command;

public interface ICommand<out TResult> : ICommand, IRequest<TResult> where TResult : class
{
}

public interface ICommand
{

}