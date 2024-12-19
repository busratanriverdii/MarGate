using MarGate.Core.DDD;

namespace MarGate.Order.Domain.Entities;

public class OrderItem : BaseEntity
{
    public long CatalogId { get; protected set; }
    public Order Order { get; protected set; }
    public long OrderId { get; protected set; }
    public int Quantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    public OrderItem(long catalogId, long orderId, int quantity, decimal unitPrice)
    {
        if (catalogId <= 0)
            throw new ArgumentException($"CatalogId must be greater than zero. Attempted to set: {catalogId}.");

        if (orderId <= 0)
            throw new ArgumentException($"OrderId must be greater than zero. Attempted to set: {orderId}.");

        if (quantity <= 0)
            throw new ArgumentException($"Quantity must be greater than zero. Attempted to set: {quantity}.");

        if (unitPrice <= 0)
            throw new ArgumentException($"Unit price must be greater than zero. Attempted to set: {unitPrice:C}.");

        CatalogId = catalogId;
        OrderId = orderId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
