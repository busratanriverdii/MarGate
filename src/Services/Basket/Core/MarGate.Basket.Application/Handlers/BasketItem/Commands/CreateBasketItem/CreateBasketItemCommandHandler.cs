using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.CreateBasketItem;

public class CreateBasketItemCommandHandler : CommandHandler<CreateBasketItemCommandRequest, CreateBasketItemCommandResponse>
{
    public override Task<CreateBasketItemCommandResponse> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
