using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Basket> _basketWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Basket>();


    public async override Task<UpdateBasketCommandResponse> Handle(UpdateBasketCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        basket.MarkAsDeleted();

        var isSuccess = _basketWriteRepository.Update(basket);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
