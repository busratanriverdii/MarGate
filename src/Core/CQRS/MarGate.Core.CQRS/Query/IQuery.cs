using MediatR;

namespace MarGate.Core.CQRS.Query
{
    public interface IQuery<out TResult> : IRequest<TResult> where TResult : class
    {
    }
}
