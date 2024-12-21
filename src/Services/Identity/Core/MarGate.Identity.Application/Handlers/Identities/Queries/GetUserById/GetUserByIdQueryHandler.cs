using Elastic.CommonSchema;
using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IReadRepository<Domain.Entities.User> _userReadRepository = unitOfWork.GetReadRepository<Domain.Entities.User>();

    public async override Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return new GetUserByIdQueryResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            EmailAddress = user.EmailAddress?.Address,
            PhoneNumber = user.PhoneNumber?.Number,
            Address = $"{user.Address.Street}, {user.Address.City}, {user.Address.Country}",
            Balance = user.Balance,
            BirthDate = user.BirthDate
        };
    }
}
