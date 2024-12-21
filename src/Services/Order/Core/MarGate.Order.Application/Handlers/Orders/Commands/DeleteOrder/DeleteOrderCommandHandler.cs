using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Order.Application.Handlers.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : CommandHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Order> _orderWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IUnitOfWork _unitOfWork)
    {
        _orderWriteRepository = _unitOfWork.GetWriteRepository<Domain.Entities.Order>();
    }

    public async override Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        order.MarkAsDeleted();

        var isSuccess = _orderWriteRepository.Update(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
