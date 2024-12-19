using MarGate.Core.CQRS.Query;
using MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;

public class GetUserByIdQueryHandler : QueryHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public override Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var users = await _userReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return users.Select(c => new GetAllUsersQueryResponse()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName
            // sadece bunlar mı dönülmeli getallusersda değiştirirsem burada da değiştirmeliyim eklemeliyim
        }).ToList();
    }
}
