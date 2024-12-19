using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Products.Queries.GetCatalogById;

public class GetProductByIdQueryHandler : QueryHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public override Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productReadRepository.GetByIdAsync(request.Id);
        return new GetProductByIdQueryResponse()
        {
            Id = product.Id,
            Name = product.Name,
            UnitsInStock = product.UnitsInStock,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }
}
