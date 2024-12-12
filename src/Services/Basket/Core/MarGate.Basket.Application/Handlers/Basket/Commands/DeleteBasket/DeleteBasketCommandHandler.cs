using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : CommandHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
{
    public override Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
