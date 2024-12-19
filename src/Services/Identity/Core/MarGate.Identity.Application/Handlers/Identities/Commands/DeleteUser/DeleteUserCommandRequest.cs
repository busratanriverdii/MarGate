using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.DeleteUser;

public class DeleteUserCommandRequest : Command<DeleteUserCommandResponse>
{
    public long Id { get; set; }
}
