using MarGate.Core.CQRS.Command;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.DeletePayment;

public class DeletePaymentCommandHandler : CommandHandler<DeletePaymentCommandRequest, DeletePaymentCommandResponse>
{
    public override Task<DeletePaymentCommandResponse> Handle(DeletePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
