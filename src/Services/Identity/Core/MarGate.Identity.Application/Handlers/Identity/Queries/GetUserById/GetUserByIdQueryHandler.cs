using MarGate.Core.CQRS.Query;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;

public class GetUserByIdQueryHandler : QueryHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    public override Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
