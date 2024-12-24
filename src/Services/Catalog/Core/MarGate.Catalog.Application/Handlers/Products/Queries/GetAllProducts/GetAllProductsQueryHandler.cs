using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Query;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Products.Queries.GetAllCatalogs;

public class GetAllProductsQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
{
    private readonly IReadRepository<Product> _productReadRepository = unitOfWork.GetReadRepository<Product>();

    public async override Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var products = await _productReadRepository.GetListAsync(cancellationToken: cancellationToken);

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
