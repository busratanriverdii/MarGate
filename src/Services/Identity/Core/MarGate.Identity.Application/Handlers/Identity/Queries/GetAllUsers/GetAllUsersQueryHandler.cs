using MarGate.Core.CQRS.Query;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : QueryHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    public override Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
