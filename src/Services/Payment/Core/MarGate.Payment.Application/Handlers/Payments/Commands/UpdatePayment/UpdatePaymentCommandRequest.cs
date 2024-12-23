using MarGate.Core.CQRS.Command;
using MarGate.Payment.Domain.Entities;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.UpdatePayment;

public class UpdatePaymentCommandRequest : Command<UpdatePaymentCommandResponse>
{
    public long Id { get; set; }
    public PaymentStatus Status { get; set; }

}
