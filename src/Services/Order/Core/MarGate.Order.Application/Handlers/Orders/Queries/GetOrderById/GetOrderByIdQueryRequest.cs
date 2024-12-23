using MarGate.Core.CQRS.Query;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetOrderById;

public class GetOrderByIdQueryRequest : Query<GetOrderByIdQueryResponse>
{
    public long Id { get; set; }
}
