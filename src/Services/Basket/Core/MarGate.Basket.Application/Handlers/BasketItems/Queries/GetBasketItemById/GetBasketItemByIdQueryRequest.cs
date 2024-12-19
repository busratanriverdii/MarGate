using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.BasketItem.Queries.GetBasketItemById;

public class GetBasketItemByIdQueryRequest : Query<GetBasketItemByIdQueryResponse>
{
    public long Id { get; set; }
}
