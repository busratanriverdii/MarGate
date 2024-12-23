using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetBasketById;

public class GetBasketByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetBasketByIdQueryRequest, GetBasketByIdQueryResponse>
{
    private readonly IReadRepository<Domain.Entities.Basket> _basketReadRepository = unitOfWork.GetReadRepository<Domain.Entities.Basket>();

    public override async Task<GetBasketByIdQueryResponse> Handle(GetBasketByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return new GetBasketByIdQueryResponse()
        {
            Id = basket.Id,
            UserId = basket.UserId,
            Items = basket.BasketItems.Select(x => new GetBasketByIdQueryResponseBasketItem()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
            }).ToList(),
        };
    }
}
