using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandHandler : CommandHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>
{
    public override Task<UpdateBasketCommandResponse> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
