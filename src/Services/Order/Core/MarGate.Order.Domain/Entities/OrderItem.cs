using MarGate.Core.DDD;

namespace MarGate.Order.Domain.Entities;

public class OrderItem : BaseEntity
{
    public long ProductId { get; protected set; }
    public Order Order { get; protected set; }
    public long OrderId { get; protected set; }
    public int Quantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    public OrderItem(long productId,  int quantity, decimal unitPrice)
    {
        if (productId <= 0)
            throw new ArgumentException($"CatalogId must be greater than zero. Attempted to set: {productId}.");

        if (quantity <= 0)
            throw new ArgumentException($"Quantity must be greater than zero. Attempted to set: {quantity}.");

        if (unitPrice <= 0)
            throw new ArgumentException($"Unit price must be greater than zero. Attempted to set: {unitPrice:C}.");

        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
