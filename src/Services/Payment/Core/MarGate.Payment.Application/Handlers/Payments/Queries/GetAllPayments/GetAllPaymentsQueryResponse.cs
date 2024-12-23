using MarGate.Payment.Domain.Entities;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetAllPayments;

public class GetAllPaymentsQueryResponse
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string TransactionId { get; set; }
    public string PaymentMethodType { get; set; }
    public string PaymentMethodToken { get; set; }
}
