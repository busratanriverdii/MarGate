namespace MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;

public class CreatePaymentCommandResponse
{
    public bool IsSuccess { get; set; }
    public long PaymentId { get; set; }
}
