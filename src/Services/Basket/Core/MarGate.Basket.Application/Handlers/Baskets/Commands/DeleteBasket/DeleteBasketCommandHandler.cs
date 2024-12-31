using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Basket.Application.Handlers.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Basket> _basketWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Basket>();

    public async override Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        basket.MarkAsDeleted();

        var isSuccess = _basketWriteRepository.Update(basket);

        return new DeleteBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
