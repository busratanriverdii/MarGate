namespace MarGate.Core.CQRS.Query;

public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> where TResult : class
{
    public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
}
