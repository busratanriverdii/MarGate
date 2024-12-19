using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.CreateBasket;

public class CreateBasketCommandRequest : Command<CreateBasketCommandResponse>
{
    public long UserId { get; set; }
}
