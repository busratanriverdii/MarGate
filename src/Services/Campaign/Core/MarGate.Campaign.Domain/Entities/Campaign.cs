namespace MarGate.Campaign.Domain.Entities;

public class Campaign
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public Discount Discount { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public bool IsActive { get; protected set; }

    public Campaign(string name, string description, Discount discount, DateTime startDate, DateTime endDate, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Campaign name cannot be empty or null. Provided name: {name ?? "null"}");
        if (startDate >= endDate) throw new ArgumentException($"Start date ({startDate}) must be earlier than end date ({endDate}).");

        Name = name;
        Description = description;
        Discount = discount;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }

    public void Activate()
    {
        if (DateTime.UtcNow > EndDate)
            throw new InvalidOperationException($"Cannot activate a campaign after its end date. Current time: {DateTime.UtcNow}, End date: {EndDate}.");

        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void ChangeDiscount(Discount newDiscount)
    {
        if (newDiscount.Percentage < 0 || newDiscount.Percentage > 100)
            throw new ArgumentException($"Discount percentage must be between 0 and 100. Provided percentage: {newDiscount.Percentage}.");

        Discount = newDiscount;
    }
}
public class Discount
{
    public double Percentage { get; protected set; }

    public Discount(double percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentException($"Discount percentage must be between 0 and 100. Provided percentage: {percentage}");

        Percentage = percentage;
    }

    public override bool Equals(object obj)
    {
        if (obj is Discount discount)
            return Percentage == discount.Percentage;
        return false;
    }

    public override int GetHashCode()
    {
        return Percentage.GetHashCode();
    }
}
