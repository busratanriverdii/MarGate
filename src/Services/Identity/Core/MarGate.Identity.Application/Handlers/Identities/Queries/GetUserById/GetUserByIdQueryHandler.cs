using MarGate.Core.Common.Exception;
using MarGate.Core.CQRS.Query;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IReadRepository<Domain.Entities.User> _userReadRepository = unitOfWork.GetReadRepository<Domain.Entities.User>();

    public async override Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (user is null)
        {
            throw new BusinessException($"user not found with id :{request.Id}", "003");
        }

        return new GetUserByIdQueryResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            EmailAddress = user.EmailAddress,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            Balance = user.Balance,
            BirthDate = user.BirthDate
        };
    }
}
