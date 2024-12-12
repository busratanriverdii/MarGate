using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Queries.GetCatalogById;

public class GetCatalogByIdQueryHandler : QueryHandler<GetCatalogByIdQueryRequest, GetCatalogByIdQueryResponse>
{
    public override Task<GetCatalogByIdQueryResponse> Handle(GetCatalogByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
