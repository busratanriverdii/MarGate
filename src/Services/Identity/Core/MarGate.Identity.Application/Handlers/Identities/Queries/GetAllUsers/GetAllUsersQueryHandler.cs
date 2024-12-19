using MarGate.Core.CQRS.Query;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : QueryHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public override Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var users = await _userReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return users.Select(c => new GetAllUsersQueryResponse()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName
            // sadece bunlar mı dönülmeli
        }).ToList();
    }
}
