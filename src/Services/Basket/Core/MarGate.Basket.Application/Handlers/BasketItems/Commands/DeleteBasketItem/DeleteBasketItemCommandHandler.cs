using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.BasketItem.Commands.DeleteBasketItem;

public class DeleteBasketItemCommandHandler : CommandHandler<DeleteBasketItemCommandRequest, DeleteBasketItemCommandResponse>
{
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;

    public DeleteBasketItemCommandHandler(IBasketItemWriteRepository basketItemWriteRepository)
    {
        _basketItemWriteRepository = basketItemWriteRepository;
    }

    public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = await _basketItemWriteRepository.FindAsync(request.Id);
        basketItem.IsDeleted = true;

        var isSuccess = _basketItemWriteRepository.Update(basketItem);
        await _basketItemWriteRepository.SaveAsync();

        return new DeleteBasketItemCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
