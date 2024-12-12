using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;

public class CreateUserCommandHandler : CommandHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    public override Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
