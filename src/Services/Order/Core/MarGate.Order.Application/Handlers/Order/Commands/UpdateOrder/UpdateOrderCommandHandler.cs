using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : CommandHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        public override Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
