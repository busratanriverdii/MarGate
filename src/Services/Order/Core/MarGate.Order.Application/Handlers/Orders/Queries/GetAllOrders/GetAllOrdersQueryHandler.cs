using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
{
    private readonly IReadRepository<Domain.Entities.Order> _orderReadRepository = unitOfWork.GetReadRepository<Domain.Entities.Order>();

    public async override Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request,
        CancellationToken cancellationToken)
    {
        var orders = await _orderReadRepository.GetListAsync(cancellationToken: cancellationToken);

        return orders.Select(order => new GetAllOrdersQueryResponse()
        {
            Id = order.Id,
            Description = order.Description
        }).ToList();
    }
}
