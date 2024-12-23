using MarGate.Core.CQRS.Query;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;

public class GetAllUsersQueryRequest : Query<List<GetAllUsersQueryResponse>>
{
}
