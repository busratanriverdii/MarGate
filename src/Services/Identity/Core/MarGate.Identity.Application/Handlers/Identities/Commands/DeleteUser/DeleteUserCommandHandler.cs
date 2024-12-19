using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.DeleteUser;

public class DeleteUserCommandHandler : CommandHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }


    public override Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FindAsync(request.Id);
        user.IsDeleted = true;

        var isSuccess = _userWriteRepository.Update(user);
        await _userWriteRepository.SaveAsync();

        return new DeleteUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
