using MarGate.Core.DDD;

namespace MarGate.Payment.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; protected set; }
    public DateTime PaymentDate { get; protected set; }
    public PaymentStatus Status { get; protected set; }
    public string TransactionId { get; protected set; }
    public PaymentMethod PaymentMethod { get; protected set; } 

    public Payment(decimal amount, PaymentMethod paymentMethod, PaymentStatus status, string transactionId)
    {
        if (amount <= 0)
            throw new ArgumentException($"Amount must be greater than zero. Attempted to set: {amount}.");

        Amount = amount;
        PaymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod), $"Payment method cannot be null.");
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

public class PaymentMethod(string type, string token)
{
    public string Type { get; protected set; } = type ?? throw new ArgumentException($"Payment method type cannot be null. Attempted to set: {type}.");
    public string Token { get; protected set; } = token ?? throw new ArgumentException($"Token cannot be null. Attempted to set: {token}.");
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled
}
