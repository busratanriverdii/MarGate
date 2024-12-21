using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandRequest : Command<CreateOrderCommandResponse>
{
    public string Description { get; set; }
    public string Address { get; set; }
    public long UserId { get; set; }

    public List<CreateOrderCommandRequestItem> Items { get; set; }
}


public class CreateOrderCommandRequestItem
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
