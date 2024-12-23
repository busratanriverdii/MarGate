using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.DeleteOrder;

public class DeleteOrderCommandRequest : Command<DeleteOrderCommandResponse>
{
    public long Id { get; set; }
}
