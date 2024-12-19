using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Products.Queries.GetAllCatalogs;

public class GetAllProductsQueryHandler : QueryHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public override Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var products = await _productReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return products.Select(p => new GetAllProductsQueryResponse()
        {
            Id = p.Id,
            Name = p.Name,
            UnitsInStock = p.UnitsInStock,
            Price = p.Price,
            CategoryId = p.CategoryId
        }).ToList();
    }
}
