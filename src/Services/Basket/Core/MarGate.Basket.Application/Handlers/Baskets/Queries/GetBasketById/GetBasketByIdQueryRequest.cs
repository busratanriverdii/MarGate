using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetBasketById;

public class GetBasketByIdQueryRequest : Query<GetBasketByIdQueryResponse>
{
    public long Id { get; set; }
}
