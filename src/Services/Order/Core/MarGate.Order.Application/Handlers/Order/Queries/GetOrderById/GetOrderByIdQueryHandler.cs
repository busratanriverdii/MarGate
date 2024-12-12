using MarGate.Core.CQRS.Query;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : QueryHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    public override Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}