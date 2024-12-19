using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandHandler(IBasketWriteRepository basketWriteRepository) : CommandHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>
{
    private readonly IBasketWriteRepository _basketWriteRepository = basketWriteRepository;

    public override Task<UpdateBasketCommandResponse> Handle(UpdateBasketCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var basket = await _basketWriteRepository.FindAsync(request.Id);

        var isSuccess = _basketWriteRepository.Update(basket);
        await _basketWriteRepository.SaveAsync();

        return new UpdateBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
