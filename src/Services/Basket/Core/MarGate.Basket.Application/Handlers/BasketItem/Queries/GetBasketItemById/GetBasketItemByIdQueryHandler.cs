using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.BasketItem.Queries.GetBasketItemById;

public class GetBasketItemByIdQueryHandler : QueryHandler<GetBasketItemByIdQueryRequest, GetBasketItemByIdQueryResponse>
{
    public override Task<GetBasketItemByIdQueryResponse> Handle(GetBasketItemByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
