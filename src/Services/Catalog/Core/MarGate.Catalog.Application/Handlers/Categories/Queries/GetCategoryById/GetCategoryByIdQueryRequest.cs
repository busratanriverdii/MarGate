using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryRequest : Query<GetCategoryByIdQueryResponse>
{
    public long Id { get; set; }
}
