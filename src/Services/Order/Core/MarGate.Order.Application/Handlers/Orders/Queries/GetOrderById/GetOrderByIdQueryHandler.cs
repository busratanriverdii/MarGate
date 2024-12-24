using MarGate.Core.CQRS.Query;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Order.Application.Handlers.Order.Queries.GetOrderById;

public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    private readonly IReadRepository<Domain.Entities.Order> _orderReadRepository = unitOfWork.GetReadRepository<Domain.Entities.Order>();

    public async override Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return new GetOrderByIdQueryResponse()
        {
            Id = order.Id,
            Description = order.Description
        };
    }
}