using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.UpdateBasketItem;

public class UpdateBasketItemCommandHandler : CommandHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
{
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;

    public UpdateBasketItemCommandHandler(IBasketItemWriteRepository basketItemWriteRepository)
    {
        _basketItemWriteRepository = basketItemWriteRepository;
    }

    //async 
    public override Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = await _basketItemWriteRepository.FindAsync(request.Id);

        var isSuccess = _basketItemWriteRepository.Update(basketItem);
        await _basketItemWriteRepository.SaveAsync();

        return new UpdateBasketItemCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
