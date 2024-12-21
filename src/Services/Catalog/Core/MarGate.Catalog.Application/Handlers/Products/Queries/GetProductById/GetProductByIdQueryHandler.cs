using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Products.Queries.GetCatalogById;

public class GetProductByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IReadRepository<Product> _productReadRepository = unitOfWork.GetReadRepository<Product>();

    public async override Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

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
