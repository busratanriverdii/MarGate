using MarGate.Core.CQRS.Query;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : QueryHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
{
    public override Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
