using MediatR;

namespace MarGate.Core.CQRS.Query;

public interface IQuery<out TResult> : IQuery, IRequest<TResult> where TResult : class
{
}

public interface IQuery
{
}