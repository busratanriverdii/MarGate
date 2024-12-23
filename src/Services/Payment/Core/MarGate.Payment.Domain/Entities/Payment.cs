using MarGate.Core.DDD;

namespace MarGate.Payment.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; protected set; }
    public DateTime PaymentDate { get; protected set; }
    public PaymentStatus Status { get; protected set; }
    public string TransactionId { get; protected set; }
    public string PaymentMethodType { get; protected set; }

    public Payment(decimal amount, string paymentMethodType, PaymentStatus status, string transactionId)
    {
        if (amount <= 0)
            throw new ArgumentException($"Amount must be greater than zero. Attempted to set: {amount}.");

        Amount = amount;
        PaymentMethodType = paymentMethodType;
        Status = status;
        TransactionId = transactionId ?? throw new ArgumentException($"Transaction ID cannot be null or empty. Attempted to set: {transactionId}.");
        PaymentDate = DateTime.Now;
    }

    public void UpdateStatus(PaymentStatus status)
    {
        Status = status;
        MarkAsModified();
    }
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled
}
