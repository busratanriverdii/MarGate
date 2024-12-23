using MarGate.Core.DDD;

namespace MarGate.Basket.Domain.Entities;

public class BasketItem : BaseEntity
{
    public long ProductId { get; protected set; }
    public Basket Basket { get; protected set; }
    public long BasketId { get; protected set; }
    public int Quantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }

    public BasketItem(long productId, int quantity, decimal unitPrice)
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

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity <= 0)
            throw new ArgumentException($"Quantity must be greater than zero. Attempted to set: {newQuantity}.");

        Quantity = newQuantity;
    }

    public void SetBasketId(long basketId)
    {
        if (basketId <= 0)
            throw new ArgumentException($"BasketId must be greater than zero. Attempted to set: {basketId}.");

        BasketId = basketId;
    }
}
