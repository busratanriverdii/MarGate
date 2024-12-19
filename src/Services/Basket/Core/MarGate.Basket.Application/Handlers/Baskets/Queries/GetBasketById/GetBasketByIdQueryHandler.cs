using MarGate.Core.CQRS.Query;

namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetBasketById;

public class GetBasketByIdQueryHandler(IBasketReadRepository basketReadRepository) : QueryHandler<GetBasketByIdQueryRequest, GetBasketByIdQueryResponse>
{
    private readonly IBasketReadRepository _basketReadRepository = basketReadRepository;

    public override Task<GetBasketByIdQueryResponse> Handle(GetBasketByIdQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var basket = await _basketReadRepository.GetByIdAsync(request.Id);
        return new GetBasketByIdQueryResponse()
        {
            Id = basket.Id,
        };
    }
}
