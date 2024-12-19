namespace MarGate.Basket.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public long UserId { get; protected set; }

        private readonly List<BasketItem> _basketItems = [];
        public IReadOnlyCollection<BasketItem> BasketItems => _basketItems.AsReadOnly();

        public Basket(long userId)
        {
            if (userId <= 0)
                throw new ArgumentException($"UserId must be greater than zero. Attempted to set: {userId}.");

            UserId = userId;
        }

        public void AddItemToBasket(BasketItem basketItem)
        {
            if (basketItem == null)
                throw new ArgumentNullException(nameof(basketItem), $"Basket item cannot be null.");

            var existingItem = _basketItems.FirstOrDefault(item => item.CatalogId == basketItem.CatalogId);
            if (existingItem != null)
            {
                // Eğer item zaten varsa, quantity güncellenebilir
                existingItem.UpdateQuantity(existingItem.Quantity + basketItem.Quantity);
            }
            else
            {
                _basketItems.Add(basketItem);
            }
        }

        public void RemoveItemFromBasket(long catalogId)
        {
            var itemToRemove = _basketItems.FirstOrDefault(item => item.CatalogId == catalogId);
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

    public class BaseEntity
    {
        public long Id { get; protected set; }
        public DateTime CreatedDate { get; } = DateTime.Now;

        private DateTime _modifiedDate;
        public DateTime ModifiedDate
        {
            get => _modifiedDate;
            private set => _modifiedDate = value;
        }

        public bool IsDeleted { get; protected set; } = false;

        public void MarkAsModified()
        {
            ModifiedDate = DateTime.Now;
        }

        public void MarkAsDeleted()
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException($"This entity has already been deleted. Cannot delete again. (ID: {Id})");
            }

            IsDeleted = true;
            MarkAsModified();
        }

        public void Restore()
        {
            if (!IsDeleted)
            {
                throw new InvalidOperationException($"This entity is not deleted. Cannot restore. (ID: {Id})");
            }

            IsDeleted = false;
            MarkAsModified();
        }

    }
}
