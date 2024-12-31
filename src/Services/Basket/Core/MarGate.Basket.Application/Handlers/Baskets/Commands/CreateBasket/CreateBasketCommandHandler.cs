using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.CreateBasket;

public class CreateBasketCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Basket> _basketWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Basket>();

    public override Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var basket = new Domain.Entities.Basket(request.UserId);

        _basketWriteRepository.Create(basket);

        return Task.FromResult(new CreateBasketCommandResponse()
        {
            IsSuccess = true,
            BasketId = basket.Id
        });
    }
}

