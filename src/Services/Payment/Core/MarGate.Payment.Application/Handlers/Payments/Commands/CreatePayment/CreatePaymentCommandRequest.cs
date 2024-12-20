using MarGate.Core.CQRS.Command;
using MarGate.Payment.Domain.Entities;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;

public class CreatePaymentCommandRequest : Command<CreatePaymentCommandResponse>
{ 
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; }
    public string TransactionId { get; set; }
}

public enum PaymentStatus
{
    Pending,      
    Completed,    
    Failed,       
    Cancelled     
}
