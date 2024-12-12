using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.BasketItem.Queries.GetAllBasketItems;

public class GetAllBasketItemsQueryHandler : QueryHandler<GetAllBasketItemsQueryRequest, List<GetAllBasketItemsQueryResponse>>
{
    public override Task<List<GetAllBasketItemsQueryResponse>> Handle(GetAllBasketItemsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
