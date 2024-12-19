using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandRequest : Command<CreateOrderCommandResponse>
{
    public string Description { get; set; }
    public string Address { get; set; }
    public long UserId { get; set; }
}
