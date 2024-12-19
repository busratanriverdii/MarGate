using MarGate.Core.CQRS.Command;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.UpdatePayment;

public class UpdatePaymentCommandHandler : CommandHandler<UpdatePaymentCommandRequest, UpdatePaymentCommandResponse>
{
    public override Task<UpdatePaymentCommandResponse> Handle(UpdatePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
