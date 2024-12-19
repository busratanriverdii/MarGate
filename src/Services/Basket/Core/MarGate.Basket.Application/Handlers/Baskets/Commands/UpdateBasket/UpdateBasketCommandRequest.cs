using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandRequest : Command<UpdateBasketCommandResponse>
{
    public long Id { get; set; }
}
