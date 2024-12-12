using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;

public class UpdateUserCommandHandler : CommandHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    public override Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
