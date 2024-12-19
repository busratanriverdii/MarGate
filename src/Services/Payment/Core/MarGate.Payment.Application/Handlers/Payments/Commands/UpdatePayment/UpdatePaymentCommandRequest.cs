using MarGate.Core.CQRS.Command;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.UpdatePayment;

public class UpdatePaymentCommandRequest : Command<UpdatePaymentCommandResponse>
{
    public long Id { get; set; }
    // other request properties
}
