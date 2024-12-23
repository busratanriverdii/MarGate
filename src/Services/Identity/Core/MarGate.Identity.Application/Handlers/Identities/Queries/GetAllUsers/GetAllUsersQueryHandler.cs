using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    private readonly IReadRepository<User> _userReadRepository = unitOfWork.GetReadRepository<User>();

    public async override Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _userReadRepository.GetListAsync(cancellationToken: cancellationToken);

        return users.Select(c => new GetAllUsersQueryResponse()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            EmailAddress = c.EmailAddress?.Address,
            PhoneNumber = c.PhoneNumber?.Number,
            Balance = c.Balance,
            BirthDate = c.BirthDate,
            Address = $"{c.Address.Street}, {c.Address.City}, {c.Address.Country}"
        }).ToList();
    }
}
