using MarGate.Core.CQRS.Query;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : QueryHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetOrderByIdQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public override Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderReadRepository.GetByIdAsync(request.Id);

        return new GetOrderByIdQueryResponse()
        {
            Id = order.Id,
            Description = order.Description
        };
    }
}