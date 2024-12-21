using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;

public class UpdateUserBalanceCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdateUserBalanceCommandRequest, UpdateUserBalanceCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<UpdateUserBalanceCommandResponse> Handle(UpdateUserBalanceCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        user.UpdateBalance(request.Amount);

        var isSuccess = _userWriteRepository.Update(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateUserBalanceCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
