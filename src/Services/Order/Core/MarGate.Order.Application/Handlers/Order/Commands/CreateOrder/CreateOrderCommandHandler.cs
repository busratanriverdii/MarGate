using MarGate.Core.CQRS.Command;

namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler : CommandHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    public override Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
