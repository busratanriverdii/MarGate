using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;


namespace MarGate.Order.Application.Handlers.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Order> _orderWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Order>();

    public async override Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        order.MarkAsDeleted();

        var isSuccess = _orderWriteRepository.Update(order);

        return new DeleteOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
