using MarGate.Core.DDD;

namespace MarGate.Basket.Domain.Entities;

public class Basket : BaseEntity
{
    public long UserId { get; protected set; }

    private readonly List<BasketItem> _basketItems = [];
    public IReadOnlyCollection<BasketItem> BasketItems => _basketItems.AsReadOnly();

    public Basket(long userId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
        UserId = userId;
    }

    public void AddItemToBasket(BasketItem basketItem)
    {
        if (basketItem == null)
            throw new ArgumentNullException(nameof(basketItem), $"Basket item cannot be null.");

        var existingItem = _basketItems.FirstOrDefault(item => item.ProductId == basketItem.ProductId);
        if (existingItem != null)
        {
            existingItem.UpdateQuantity(existingItem.Quantity + basketItem.Quantity);
        }
        else
        {
            _basketItems.Add(basketItem);
        }
    }

    public void RemoveItemFromBasket(long catalogId)
    {
        var itemToRemove = _basketItems.FirstOrDefault(item => item.ProductId == catalogId);
        if (itemToRemove != null)
        {
            _basketItems.Remove(itemToRemove);
        }
        else
        {
            throw new InvalidOperationException($"No item found with CatalogId: {catalogId}.");
        }
    }
}
