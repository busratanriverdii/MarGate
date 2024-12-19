using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.BasketItem.Queries.GetAllBasketItems;

public class GetAllBasketItemsQueryHandler : QueryHandler<GetAllBasketItemsQueryRequest, List<GetAllBasketItemsQueryResponse>>
{
    private readonly IBasketItemReadRepository _basketItemReadRepository;

    public override Task<List<GetAllBasketItemsQueryResponse>> Handle(GetAllBasketItemsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var basketItems = await _basketItemReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return basketItems.Select(p => new GetAllBasketItemsQueryResponse()
        {
            // bind
        }).ToList();
    }
}
