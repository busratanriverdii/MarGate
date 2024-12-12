using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.DeleteBasketItem;

public class DeleteBasketItemCommandRequest : Command<DeleteBasketItemCommandResponse>
{
    public long Id { get; set; }
}
