using MarGate.Core.CQRS.Query;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryRequest : Query<List<GetAllOrdersQueryResponse>>
{
}
