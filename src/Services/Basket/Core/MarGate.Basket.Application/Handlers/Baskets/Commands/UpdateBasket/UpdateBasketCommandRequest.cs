using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandRequest : Command<UpdateBasketCommandResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public List<BasketItemUpdateDto> Items { get; set; }
}

public class BasketItemUpdateDto
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}