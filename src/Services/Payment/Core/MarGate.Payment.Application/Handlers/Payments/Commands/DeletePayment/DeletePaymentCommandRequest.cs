using MarGate.Core.CQRS.Command;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.DeletePayment;

public class DeletePaymentCommandRequest : Command<DeletePaymentCommandResponse>
{
    public long Id { get; set; }
}
