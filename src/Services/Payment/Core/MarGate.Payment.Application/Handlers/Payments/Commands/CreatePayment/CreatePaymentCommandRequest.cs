using MarGate.Core.CQRS.Command;

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
    Pending,      // Ödeme beklemede
    Completed,    // Ödeme tamamlanmış
    Failed,       // Ödeme başarısız
    Cancelled     // Ödeme iptal edilmiş
}
