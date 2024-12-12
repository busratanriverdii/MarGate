namespace MarGate.Catalog.Domain.Entities
{
    public class Catalog : BaseEntity
    {
        public string Name { get; protected set; }
        public int UnitsInStock { get; protected set; }
        public decimal Price { get; protected set; }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Name cannot be null or empty. Attempted to set to: {name}.");
            }

            if (name.Length < 3)
            {
                throw new ArgumentException($"Name must be at least 3 characters long. Attempted to set: {name}.");
            }

            if (name.Length > 100)
            {
                throw new ArgumentException($"Name cannot exceed 100 characters. Attempted to set: {name}.");
            }

            Name = name;
        }

        public void SetUnitsInStock(int unitsInStock)
        {
            if (unitsInStock < 0)
            {
                throw new ArgumentException($"Units in stock cannot be negative. Attempted to set to {unitsInStock}.");
            }

            UnitsInStock = unitsInStock;
        }

        public void AddStock(int quantityToAdd)
        {
            if (quantityToAdd <= 0)
            {
                throw new ArgumentException($"Quantity to add must be greater than zero. Attempted to add {quantityToAdd}.");
            }

            UnitsInStock += quantityToAdd;
        }

        public void RemoveStock(int quantityToRemove)
        {
            if (quantityToRemove <= 0)
            {
                throw new ArgumentException($"Quantity to remove must be greater than zero. Attempted to remove {quantityToRemove}.");
            }

            if (UnitsInStock - quantityToRemove < 0)
            {
                throw new InvalidOperationException($"Not enough stock to remove. Current stock: {UnitsInStock}, attempted to remove: {quantityToRemove}.");
            }

            UnitsInStock -= quantityToRemove;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException($"Price cannot be negative. Attempted to set price to {price:C}.");
            }

            Price = price;
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
