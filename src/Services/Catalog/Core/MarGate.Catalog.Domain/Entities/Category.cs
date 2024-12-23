using MarGate.Core.DDD;

namespace MarGate.Catalog.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }

    private List<Product> _products = [];
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public Category(string name, string description)
    {
        GuardAgainstInvalidArguments(name, description);

        Name = name;
        Description = description;
    }

    public void AddProduct(Product product)
    {
        GuardAgainstNullProduct(product);

        _products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        GuardAgainstNullProduct(product);

        _products.Remove(product);
    }

    public bool IsEmpty()
    {
        return _products.Count == 0;
    }

    public void ChangeCategoryName(string newName)
    {
        GuardAgainstInvalidCategoryName(newName);

        Name = newName;
    }

    public void ChangeCategoryDescription(string newDescription)
    {
        GuardAgainstInvalidCategoryDescription(newDescription);

        Description = newDescription;
    }


    private void GuardAgainstInvalidArguments(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Category name cannot be null or empty. Provided value: '{name}'", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException($"Category description cannot be null or empty. Provided value: '{description}'", nameof(description));
    }

    private void GuardAgainstNullProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), $"Product cannot be null. Provided product: '{product}'");
    }

    private void GuardAgainstInvalidCategoryName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException($"New category name cannot be null or empty. Provided value: '{newName}'", nameof(newName));
    }

    private void GuardAgainstInvalidCategoryDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException($"New category description cannot be null or empty. Provided value: '{newDescription}'", nameof(newDescription));
    }
}
