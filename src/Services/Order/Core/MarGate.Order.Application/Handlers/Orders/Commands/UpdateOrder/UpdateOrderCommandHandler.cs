using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : CommandHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public UpdateOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public override Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FindAsync(request.Id);

        order.Description = request.Description;
        order.Address = request.Address;

        var isSuccess = _orderWriteRepository.Update(order);
        await _orderWriteRepository.SaveAsync();

        return new UpdateOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
