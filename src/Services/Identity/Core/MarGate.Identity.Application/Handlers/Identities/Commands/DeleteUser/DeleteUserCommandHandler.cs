using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        user.MarkAsDeleted();

        var isSuccess = _userWriteRepository.Update(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
