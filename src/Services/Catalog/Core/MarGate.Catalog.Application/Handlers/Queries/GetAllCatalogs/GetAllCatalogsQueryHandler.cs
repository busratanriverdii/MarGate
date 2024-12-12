using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Queries.GetAllCatalogs;

public class GetAllCatalogsQueryHandler : QueryHandler<GetAllCatalogsQueryRequest, List<GetAllCatalogsQueryResponse>>
{
    public override Task<List<GetAllCatalogsQueryResponse>> Handle(GetAllCatalogsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
