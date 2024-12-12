using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : CommandHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    public override Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
