using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetBasketById;

public class GetBasketByIdQueryHandler : QueryHandler<GetBasketByIdQueryRequest, GetBasketByIdQueryResponse>
{
    public override Task<GetBasketByIdQueryResponse> Handle(GetBasketByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
