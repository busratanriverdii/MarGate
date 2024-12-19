using MarGate.Core.CQRS.Query;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : QueryHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetAllOrdersQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public override Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var orders = await _orderReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return orders.Select(order => new GetAllOrdersQueryResponse()
        {
            Id = order.Id,
            Description = order.Description
        }).ToList();
    }
}
