using MarGate.Core.Mongo;

namespace MarGate.Campaign.Domain.Entities;

public class Campaign : MongoBaseEntity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public decimal DiscountRate { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public bool IsActive { get; protected set; }

    public Campaign(string name, string description, decimal discountRate, DateTime startDate, DateTime endDate, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Campaign name cannot be empty or null. Provided name: {name ?? "null"}");
        if (startDate >= endDate) throw new ArgumentException($"Start date ({startDate}) must be earlier than end date ({endDate}).");

        Name = name;
        Description = description;
        DiscountRate = discountRate;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetDiscountRate(decimal discountRate)
    {
        DiscountRate = discountRate;
    }

    public void SetCampaignIntervalDate(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
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
}

