using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetAllBaskets;

public class GetAllBasketsQueryHandler : QueryHandler<GetAllBasketsQueryRequest, List<GetAllBasketsQueryResponse>>
{
    public override Task<List<GetAllBasketsQueryResponse>> Handle(GetAllBasketsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
