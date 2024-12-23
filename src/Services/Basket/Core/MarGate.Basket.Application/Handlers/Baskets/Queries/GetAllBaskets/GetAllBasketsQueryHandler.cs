using MarGate.Core.CQRS.Query;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetAllBaskets;

public class GetAllBasketsQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetAllBasketsQueryRequest, List<GetAllBasketsQueryResponse>>
{
    private readonly IReadRepository<Domain.Entities.Basket> _basketReadRepository = unitOfWork.GetReadRepository<Domain.Entities.Basket>();

    public override async Task<List<GetAllBasketsQueryResponse>> Handle(GetAllBasketsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var baskets = await _basketReadRepository.GetListAsync(cancellationToken: cancellationToken);

        return baskets.Select(b => new GetAllBasketsQueryResponse()
        {
            Id = b.Id,
            UsertId = b.UserId,
            Items = b.BasketItems.Select(x => new GetAllBasketsQueryResponseBasketItem()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
            }).ToList(),

        }).ToList();
    }
}
