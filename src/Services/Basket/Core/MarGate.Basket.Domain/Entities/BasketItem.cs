namespace MarGate.Basket.Domain.Entities;

public class BasketItem : BaseEntity
{
    public long CatalogId { get; protected set; }
    public Basket Basket { get; protected set; }
    public long BasketId { get; protected set; }
    public int Quantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    //basketitem uyarıyor
    public BasketItem(long catalogId, int quantity, decimal unitPrice)
    {
        if (catalogId <= 0)
            throw new ArgumentException($"CatalogId must be greater than zero. Attempted to set: {catalogId}.");
        if (quantity <= 0)
            throw new ArgumentException($"Quantity must be greater than zero. Attempted to set: {quantity}.");
        if (unitPrice <= 0)
            throw new ArgumentException($"Unit price must be greater than zero. Attempted to set: {unitPrice:C}.");

        CatalogId = catalogId;
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
