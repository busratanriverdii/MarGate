using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandRequest : Command<DeleteBasketCommandResponse>
{
    public long Id { get; set; }
}