using MarGate.Core.CQRS.Command;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.CreateBasket;


public class CreateBasketCommandHandler(IBasketWriteRepository basketWriteRepository) : CommandHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
{
    private readonly IBasketWriteRepository _basketWriteRepository = basketWriteRepository;

    public CreateBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
    {
        _basketWriteRepository = basketWriteRepository;
    }

    public override async Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var basket = new Basket()
        {
            UserId = request.UserId
        };

        var isSuccess = await _basketWriteRepository.CreateAsync(basket);
        await _basketWriteRepository.SaveAsync();

        return new CreateBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}

