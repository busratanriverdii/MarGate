using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetAllBaskets;

public class GetAllBasketsQueryHandler(IBasketReadRepository basketReadRepository) : QueryHandler<GetAllBasketsQueryRequest, List<GetAllBasketsQueryResponse>>
{
    private readonly IBasketReadRepository _basketReadRepository = basketReadRepository;

    public override Task<List<GetAllBasketsQueryResponse>> Handle(GetAllBasketsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var baskets = await _basketReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return baskets.Select(p => new GetAllBasketsQueryResponse()
        {
            //bind
        }).ToList();
    }
}
