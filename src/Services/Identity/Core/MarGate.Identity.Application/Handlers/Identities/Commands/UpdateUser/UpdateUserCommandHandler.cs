using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;

public class UpdateUserCommandHandler : CommandHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public UpdateUserBalanceCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public override Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FindAsync(request.Id);
        user.Balance = user.Balance - request.Amount;

        var isSuccess = _userWriteRepository.Update(user);
        await _userWriteRepository.SaveAsync();

        return new UpdateUserBalanceCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
