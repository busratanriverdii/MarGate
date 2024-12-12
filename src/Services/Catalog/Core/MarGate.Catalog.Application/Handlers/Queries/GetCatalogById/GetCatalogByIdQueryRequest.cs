using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Queries.GetCatalogById;

public class GetCatalogByIdQueryRequest : Query<GetCatalogByIdQueryResponse>
{
    public long Id { get; set; }
}
