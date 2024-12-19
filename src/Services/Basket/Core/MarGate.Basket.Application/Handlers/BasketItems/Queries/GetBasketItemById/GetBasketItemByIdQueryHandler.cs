using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.BasketItem.Queries.GetBasketItemById;

public class GetBasketItemByIdQueryHandler : QueryHandler<GetBasketItemByIdQueryRequest, GetBasketItemByIdQueryResponse>
{
    private readonly IBasketItemReadRepository _basketItemReadRepository;

    public GetBasketItemByIdQueryHandler(IBasketItemReadRepository basketItemReadRepository)
    {
        _basketItemReadRepository = basketItemReadRepository;
    }

    public override Task<GetBasketItemByIdQueryResponse> Handle(GetBasketItemByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = await _basketItemReadRepository.GetByIdAsync(request.Id);
        return new GetBasketItemByIdQueryResponse()
        {
            Id = basketItem.Id,
        };
    }
}
