using MarGate.Identity.Domain.Entities;

namespace MarGate.Order.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; protected set; }
    public Address ShippingAddress { get; protected set; } // Value Object
    public User User { get; protected set; }
    public long UserId { get; protected set; }
    public ICollection<OrderItem> OrderItems { get; protected set; }
    public decimal TotalAmount => OrderItems.Sum(item => item.TotalPrice); // Total amount calculated from OrderItems

    // Constructor to initialize order with user and address
    public Order(User user, Address shippingAddress, string description)
    {
        if (user == null) throw new ArgumentNullException(nameof(user), "$User cannot be null");
        if (shippingAddress == null) throw new ArgumentNullException(nameof(shippingAddress), "$Shipping Address cannot be null");
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("$Description cannot be empty");

        User = user;
        UserId = user.Id; 
        ShippingAddress = shippingAddress;
        Description = description;
        OrderItems = []; 
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException(nameof(orderItem), "$Order item cannot be null.");

        OrderItems.Add(orderItem);
        MarkAsModified(); // mark as modified
    }

    public decimal CalculateTotalAmount()
    {
        return OrderItems.Sum(item => item.TotalPrice);
    }



    public class Address : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public Address(string street, string city, string state, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street cannot be empty");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty");
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("State cannot be empty");
            if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("PostalCode cannot be empty");
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country cannot be empty");

            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }

        protected override bool EqualsCore(ValueObject other)
        {
            var otherAddress = other as Address;
            return otherAddress != null &&
                   Street == otherAddress.Street &&
                   City == otherAddress.City &&
                   State == otherAddress.State &&
                   PostalCode == otherAddress.PostalCode &&
                   Country == otherAddress.Country;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Street, City, State, PostalCode, Country);
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

    //public BaseEntity(long id)
    //{
    //    if (id <= 0)
    //    {
    //        throw new ArgumentException($"Id must be a positive value. Attempted to set Id to: {id}.");
    //    }

    //    Id = id;
    //}

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