using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.UpdateBasketItem;

public class UpdateBasketItemCommandHandler : CommandHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
{
    public override Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
