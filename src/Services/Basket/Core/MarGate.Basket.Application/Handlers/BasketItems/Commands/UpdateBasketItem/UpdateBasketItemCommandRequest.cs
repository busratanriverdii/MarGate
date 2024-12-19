using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.UpdateBasketItem;

public class UpdateBasketItemCommandRequest : Command<UpdateBasketItemCommandResponse>
{
    public long Id { get; set; }
}
