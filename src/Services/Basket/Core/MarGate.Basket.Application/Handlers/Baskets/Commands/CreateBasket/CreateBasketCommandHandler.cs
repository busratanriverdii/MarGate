using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.CreateBasket;

public class CreateBasketCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Basket> _basketWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Basket>();

    public override async Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var basket = new Domain.Entities.Basket(request.UserId);

        var id = _basketWriteRepository.Create(basket);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateBasketCommandResponse()
        {
            IsSuccess = true,
            BasketId = id
        };
    }
}

