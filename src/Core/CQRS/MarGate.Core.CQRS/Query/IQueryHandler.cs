using MediatR;

namespace MarGate.Core.CQRS.Query
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> where TResult : class
    {

    }
}
