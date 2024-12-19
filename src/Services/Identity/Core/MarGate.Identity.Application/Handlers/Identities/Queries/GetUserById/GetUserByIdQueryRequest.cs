using MarGate.Core.CQRS.Query;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;

public class GetUserByIdQueryRequest : Query<GetUserByIdQueryResponse>
{
    public long Id { get; set; }
}
