using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;

public class UpdateUserBalanceCommandRequest : Command<UpdateUserBalanceCommandResponse>
{
    public long Id { get; set; }
    public decimal Amount{ get; set; }
}
