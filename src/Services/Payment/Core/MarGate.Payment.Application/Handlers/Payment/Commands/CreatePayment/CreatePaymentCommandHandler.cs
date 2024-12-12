using MarGate.Core.CQRS.Command;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;

public class CreatePaymentCommandHandler : CommandHandler<CreatePaymentCommandRequest, CreatePaymentCommandResponse>
{
    public override Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
