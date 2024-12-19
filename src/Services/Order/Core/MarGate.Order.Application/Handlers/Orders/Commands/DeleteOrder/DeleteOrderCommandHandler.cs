using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : CommandHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public override Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FindAsync(request.Id);
        order.IsDeleted = true;

        var isSuccess = _orderWriteRepository.Update(order);
        await _orderWriteRepository.SaveAsync();

        return new DeleteOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
