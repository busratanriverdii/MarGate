using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.UpdateOrder;

public class UpdateOrderCommandRequest : Command<UpdateOrderCommandResponse>
{
    public long Id { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
}
