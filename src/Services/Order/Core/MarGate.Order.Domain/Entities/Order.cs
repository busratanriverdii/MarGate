using MarGate.Core.DDD;

namespace MarGate.Order.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; protected set; }
    public string Address { get; protected set; }
    public long UserId { get; protected set; }
    public ICollection<OrderItem> OrderItems { get; protected set; } = [];
    public decimal TotalAmount => OrderItems.Sum(item => item.TotalPrice);

    public Order(long userId, string address, string description)
    {
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("$Description cannot be empty");

        UserId = userId;
        Address = address;
        Description = description;
        OrderItems = [];
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetAddress(string address)
    {
        Address = address;
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException(nameof(orderItem), "$Order item cannot be null.");

        OrderItems.Add(orderItem);
        MarkAsModified(); 
    }

    public decimal CalculateTotalAmount()
    {
        return OrderItems.Sum(item => item.TotalPrice);
    }
}
