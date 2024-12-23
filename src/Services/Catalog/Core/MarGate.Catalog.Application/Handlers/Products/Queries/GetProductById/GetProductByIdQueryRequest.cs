using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Products.Queries.GetCatalogById;

public class GetProductByIdQueryRequest : Query<GetProductByIdQueryResponse>
{
    public long Id { get; set; }
}
