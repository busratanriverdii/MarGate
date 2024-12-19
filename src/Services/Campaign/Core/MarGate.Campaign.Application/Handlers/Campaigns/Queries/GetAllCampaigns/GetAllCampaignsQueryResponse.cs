namespace MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetAllCampaigns;

public class GetAllCampaignsQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}
