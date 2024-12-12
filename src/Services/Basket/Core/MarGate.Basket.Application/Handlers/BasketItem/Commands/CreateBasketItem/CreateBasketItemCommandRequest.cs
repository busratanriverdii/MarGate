using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.CreateBasketItem;

public class CreateBasketItemCommandRequest : Command<CreateBasketItemCommandResponse>
{
    public long ProductId { get; set; }
    public long BasketId { get; set; }
}
