using MediatR;

namespace MarGate.Core.CQRS.Command
{
    public interface ICommand<out TResult> : IRequest<TResult> where TResult : class
    {
    }
}
