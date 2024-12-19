using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : CommandHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
{
    private readonly IBasketWriteRepository _basketWriteRepository;

    public DeleteBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
    {
        _basketWriteRepository = basketWriteRepository;
    }

    public override Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var basket = await _basketWriteRepository.FindAsync(request.Id);
        basket.IsDeleted = true;

        var isSuccess = _basketWriteRepository.Update(basket);
        await _basketWriteRepository.SaveAsync();

        return new DeleteBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
